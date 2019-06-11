namespace Blorc.Bindings
{
    using System;
    using Blorc.Logging;

    /// <summary>
    /// Base class for all bindings.
    /// </summary>
    public abstract class BindingBase : IDisposable
    {
        private string _toStringValue;
        private bool _disposedValue;

        /// <summary>
        /// Determines the value to use in the <see cref="ToString"/> method.
        /// </summary>
        /// <returns>The string to use.</returns>
        protected abstract string DetermineToString();

        /// <summary>
        /// Uninitializes this binding.
        /// </summary>
        protected abstract void Uninitialize();

        private void UninitializeBinding()
        {
            Uninitialize();

            Log.Debug($"Uninitialized binding '{this}'");
        }

        /// <summary>
        /// Converts the current instance to a string.
        /// </summary>
        /// <returns>The string representation of this object.</returns>
        public override string ToString()
        {
            if (_toStringValue is null)
            {
                _toStringValue = DetermineToString();
            }

            return _toStringValue;
        }

        /// <summary>
        /// Clears the binding and stops listening to both the source and target instances.
        /// </summary>
        public void ClearBinding()
        {
            UninitializeBinding();
        }

        protected virtual void DisposeManaged()
        {
            ClearBinding();
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
