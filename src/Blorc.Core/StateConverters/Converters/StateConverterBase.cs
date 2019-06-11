namespace Blorc.StateConverters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class StateConverterBase : IStateConverter
    {
        protected readonly Func<string> ValueFunc;
        protected readonly Func<bool> Predicate;

        private bool _disposedValue;

        public StateConverterBase(Func<string> valueFunc, Func<bool> predicate)
        {
            ValueFunc = valueFunc;
            Predicate = predicate;
        }

        public virtual string GetValue()
        {
            var predicate = Predicate;
            if (predicate != null)
            {
                if (!predicate())
                {
                    return null;
                }
            }

            return ValueFunc();
        }

        protected virtual void DisposeManaged()
        {

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
