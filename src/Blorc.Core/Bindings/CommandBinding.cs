namespace Blorc.Bindings
{
    using System.Reflection;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Binding to bind events to commands.
    /// </summary>
    public class CommandBinding : BindingBase
    {
        private object _element;
        private EventInfo _eventInfo;
        private PropertyInfo _enabledPropertyInfo;
        private ICommand _command;
        private Binding _commandParameterBinding;

        private EventHandler<EventArgs> _eventHandler;
        private EventHandler<EventArgs> _canExecuteChangedHandler;
        private EventHandler<EventArgs> _commandBindingParameterValueChangedHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBinding"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="command">The command.</param>
        /// <param name="commandParameterBinding">The command parameter binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="element"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="eventName"/> is <c>null</c> or whitespace.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="command"/> is <c>null</c>.</exception>
        public CommandBinding(object element, string eventName, ICommand command, Binding commandParameterBinding = null)
        {
            _element = element;
            _command = command;
            _commandParameterBinding = commandParameterBinding;

            var elementType = _element.GetType();
            _eventInfo = elementType.GetEvent(eventName);
            if (_eventInfo is null)
            {
                throw new InvalidOperationException($"Event '{elementType.Name}.{eventName}' not found, cannot create command binding");
            }

            _enabledPropertyInfo = elementType.GetProperty("Enabled");

            _eventHandler = async delegate
            {
                var commandParameter = _commandParameterBinding.GetBindingValue();
                if (await _command.CanExecuteAsync(commandParameter))
                {
                    await _command.ExecuteAsync(commandParameter);
                }
            };
            _eventInfo.AddEventHandler(element, _eventHandler);

            _canExecuteChangedHandler = async (sender, e) => await UpdateEnabledStateAsync();
            command.CanExecuteChanged += _canExecuteChangedHandler;

            if (commandParameterBinding != null)
            {
                _commandBindingParameterValueChangedHandler = async (sender, e) => await UpdateEnabledStateAsync();
                commandParameterBinding.ValueChanged += _commandBindingParameterValueChangedHandler;
            }

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            UpdateEnabledStateAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        #region Methods
        /// <summary>
        /// Determines the value to use in the <see cref="BindingBase.ToString"/> method.
        /// </summary>
        /// <returns>The string to use.</returns>
        protected override string DetermineToString()
        {
            var elementType = _element.GetType();

            return string.Format("{0}.{1}", elementType.Name, _eventInfo.Name);
        }

        /// <summary>
        /// Uninitializes this binding.
        /// </summary>
        protected override void Uninitialize()
        {
            if (_eventHandler != null)
            {
                _eventInfo.RemoveEventHandler(_element, _eventHandler);
                _eventHandler = null;
            }

            if (_canExecuteChangedHandler != null)
            {
                _command.CanExecuteChanged -= _canExecuteChangedHandler;
                _canExecuteChangedHandler = null;
            }

            if (_commandBindingParameterValueChangedHandler != null)
            {
                _commandParameterBinding.ValueChanged -= _commandBindingParameterValueChangedHandler;
                _commandBindingParameterValueChangedHandler = null;
            }

            _element = null;
            _eventInfo = null;
            _enabledPropertyInfo = null;
            _command = null;
            _commandParameterBinding = null;

            // TODO: call commandParameterBinding.ClearBinding();?
        }

        private async Task UpdateEnabledStateAsync()
        {
            if (_enabledPropertyInfo is null)
            {
                return;
            }

            var commandParameter = _commandParameterBinding.GetBindingValue();
            _enabledPropertyInfo.SetValue(_element, await _command.CanExecuteAsync(commandParameter));
        }
        #endregion
    }
}
