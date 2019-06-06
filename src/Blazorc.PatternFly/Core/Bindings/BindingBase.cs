namespace Blazorc.PatternFly.Bindings
{
    /// <summary>
    /// Base class for all bindings.
    /// </summary>
    public abstract class BindingBase
    {
        private string _toStringValue;

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
    }
}
