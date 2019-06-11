namespace Blorc.Bindings
{
    using System;
    using System.Collections.Generic;
    using Blorc.Logging;
    using Blorc.MVVM;

    /// <summary>
    /// Binding context that takes care of binding updates.
    /// </summary>
    public class BindingContext : IDisposable
    {
        #region Fields
        private readonly List<Binding> _bindings = new List<Binding>();
        private readonly List<CommandBinding> _commandBindings = new List<CommandBinding>();

        //private int? _lastViewModelId;
        private bool _disposedValue;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BindingContext"/> class.
        /// </summary>
        public BindingContext()
        {
            //UniqueIdentifier = UniqueIdentifierHelper.GetUniqueIdentifier<BindingContext>();
        }

        #region Properties
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public int UniqueIdentifier { get; private set; }

        /// <summary>
        /// Gets the get bindings.
        /// </summary>
        /// <value>The get bindings.</value>
        public IEnumerable<Binding> GetBindings
        {
            get { return _bindings.ToArray(); }
        }

        /// <summary>
        /// Gets the get command bindings.
        /// </summary>
        /// <value>The get command bindings.</value>
        public IEnumerable<CommandBinding> GetCommandBindings
        {
            get { return _commandBindings.ToArray(); }
        }
        #endregion

        #region Events
        ///// <summary>
        ///// Occurs when binding updates are required.
        ///// </summary>
        //public event EventHandler<EventArgs> BindingUpdateRequired;
        #endregion

        #region Methods
        /// <summary>
        /// Clears this binding context and all bindings.
        /// </summary>
        public void Clear()
        {
            //Log.Debug("Clearing binding context");

            _bindings.ForEach(x => x.Dispose());
            _bindings.Clear();

            _commandBindings.ForEach(x => x.Dispose());
            _commandBindings.Clear();
        }

        /// <summary>
        /// Adds a new binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="binding"/> is <c>null</c>.</exception>
        public void AddBinding(Binding binding)
        {
            //Log.Debug($"Adding binding '{binding}'");

            _bindings.Add(binding);
        }

        /// <summary>
        /// Removes the binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="binding"/> is <c>null</c>.</exception>
        public void RemoveBinding(Binding binding)
        {
            //Log.Debug($"Removing binding '{binding}'");

            for (var i = 0; i < _bindings.Count; i++)
            {
                if (ReferenceEquals(_bindings[i], binding))
                {
                    _bindings.RemoveAt(i);
                    return;
                }
            }
        }

        /// <summary>
        /// Adds a new command binding.
        /// </summary>
        /// <param name="commandBinding">The command binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="commandBinding"/> is <c>null</c>.</exception>
        public void AddCommandBinding(CommandBinding commandBinding)
        {
            //Log.Debug($"Adding command binding '{commandBinding}'");

            _commandBindings.Add(commandBinding);
        }

        /// <summary>
        /// Removes the command binding.
        /// </summary>
        /// <param name="commandBinding">The command binding.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="commandBinding"/> is <c>null</c>.</exception>
        public void RemoveCommandBinding(CommandBinding commandBinding)
        {
            //Log.Debug($"Removing command binding '{commandBinding}'");

            for (var i = 0; i < _commandBindings.Count; i++)
            {
                if (ReferenceEquals(_commandBindings[i], commandBinding))
                {
                    _commandBindings.RemoveAt(i);
                    return;
                }
            }
        }

        ///// <summary>
        ///// Updates the view model of this binding context.
        ///// <para />
        ///// This method can be called as much as required, it will automatically determine if binding
        ///// updates are required.
        ///// </summary>
        ///// <param name="viewModel">The view model.</param>
        //public void DetermineIfBindingsAreRequired(IViewModel viewModel)
        //{
        //    int? currentViewModelId = null;
        //    if (viewModel != null)
        //    {
        //        currentViewModelId = viewModel.UniqueIdentifier;
        //    }

        //    if (_lastViewModelId != currentViewModelId)
        //    {
        //        if (_lastViewModelId.HasValue)
        //        {
        //            Clear();
        //        }

        //        if (viewModel != null)
        //        {
        //            BindingUpdateRequired?.Invoke(this, EventArgs.Empty);
        //        }

        //        _lastViewModelId = currentViewModelId;
        //    }
        //}
        #endregion

        protected virtual void DisposeManaged()
        {
            Clear();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    DisposeManaged();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
