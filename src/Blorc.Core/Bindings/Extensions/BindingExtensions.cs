namespace Blorc.Bindings
{
    using System;

    /// <summary>
    /// Extension methods to create bindings on platforms that initially don't support bindings.
    /// </summary>
    public static class BindingExtensions
    {
        #region Methods
        /// <summary>
        /// Adds an additional event subscription to support change notification.
        /// <para />
        /// This extension method will use the <see cref="Binding.Target" /> to add an event.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>Catel.MVVM.Binding.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="binding" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="eventName" /> is <c>null</c> or whitespace.</exception>
        public static Binding AddTargetEvent(this Binding binding, string eventName)
        {
            binding.Target.AddEvent(eventName);

            return binding;
        }

        /// <summary>
        /// Adds an additional event subscription to support change notification.
        /// <para />
        /// This extension method will use the <see cref="Binding.Target" /> to add an event.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>Catel.MVVM.Binding.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="binding"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="eventName"/> is <c>null</c> or whitespace.</exception>
        public static Binding AddTargetEvent<TEventArgs>(this Binding binding, string eventName)
            where TEventArgs : EventArgs
        {
            binding.Target.AddEvent<TEventArgs>(eventName);

            return binding;
        }

        /// <summary>
        /// Adds an additional event subscription to support change notification.
        /// <para />
        /// This extension method will use the <see cref="Binding.Source" /> to add an event.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>Catel.MVVM.Binding.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="binding"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="eventName"/> is <c>null</c> or whitespace.</exception>
        public static Binding AddSourceEvent(this Binding binding, string eventName)
        {
            binding.Source.AddEvent(eventName);

            return binding;
        }

        /// <summary>
        /// Adds an additional event subscription to support change notification.
        /// <para />
        /// This extension method will use the <see cref="Binding.Source" /> to add an event.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>Catel.MVVM.Binding.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="binding"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The <paramref name="eventName"/> is <c>null</c> or whitespace.</exception>
        public static Binding AddSourceEvent<TEventArgs>(this Binding binding, string eventName)
            where TEventArgs : EventArgs
        {
            binding.Source.AddEvent<TEventArgs>(eventName);

            return binding;
        }

        /// <summary>
        /// Gets the binding value. 
        /// <para />
        /// If the <paramref name="binding"/> is <c>null</c>, this method will return <c>null</c>.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <returns>The binding value.</returns>
        public static object GetBindingValue(this Binding binding)
        {
            if (binding is null)
            {
                return null;
            }

            return binding.Value;
        }
        #endregion
    }
}
