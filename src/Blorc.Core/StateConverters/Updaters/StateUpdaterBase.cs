namespace Blorc.StateConverters
{
    using System;

    public abstract class StateUpdaterBase : IStateUpdater, IDisposable
    {
        private readonly Action<string> _updater;

        private bool _disposedValue = false;

        public StateUpdaterBase(Action<string> updater)
        {
            _updater = updater;
        }

        public virtual void Update(string value)
        {
            _updater(value);
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
