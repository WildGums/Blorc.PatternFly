namespace Blorc.StateConverters
{
    using System;

    public abstract class StateWatcherBase : IStateWatcher, IDisposable
    {
        private bool _disposedValue = false;

        public event EventHandler<EventArgs> StateChanged;

        protected virtual void RaiseStateChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
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
