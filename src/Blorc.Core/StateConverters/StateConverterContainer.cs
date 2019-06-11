namespace Blorc.StateConverters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Blorc.Components;

    public class StateConverterContainer : IStateConverterContainer
    {
        private readonly List<IStateConverter> _converters = new List<IStateConverter>();
        private readonly List<IStateWatcher> _watchers = new List<IStateWatcher>();
        private readonly List<IStateUpdater> _updaters = new List<IStateUpdater>();

        private readonly BlorcComponentBase _component;
        private bool _disposedValue;
        private bool _isUpdating;
        private bool _forceComponentUpdate;

        internal StateConverterContainer(BlorcComponentBase component)
        {
            _component = component;
            _forceComponentUpdate = true;
        }

        public string GetValue()
        {
            var items = _converters.Select(x => x.GetValue());
            return string.Join(" ", items.Where(x => x != null));
        }

        public StateConverterContainer Add(IStateConverter converter)
        {
            _converters.Add(converter);
            return this;
        }

        public StateConverterContainer Add(IStateWatcher watcher)
        {
            _watchers.Add(watcher);

            watcher.StateChanged += OnWatcherStateChanged;

            return this;
        }

        public StateConverterContainer Add(IStateUpdater updater)
        {
            _updaters.Add(updater);
            return this;
        }

        public StateConverterContainer DoNotForceComponentUpdate()
        {
            _forceComponentUpdate = false;
            return this;
        }

        public void MarkDirty()
        {
            UpdateTargets();
        }

        private void OnWatcherStateChanged(object sender, EventArgs e)
        {
            UpdateTargets();
        }

        private void UpdateTargets()
        {
            if (_isUpdating)
            {
                return;
            }

            _isUpdating = true;

            var value = GetValue();

            _updaters.ForEach(updater => updater.Update(value));

            if (_forceComponentUpdate)
            {
                _component.ForceUpdate();
            }

            _isUpdating = false;
        }

        protected virtual void DisposeManaged()
        {
            _updaters.ForEach(x => x.Dispose());
            _updaters.Clear();

            _watchers.ForEach(x =>
            {
                x.StateChanged -= OnWatcherStateChanged;
                x.Dispose();
            });
            _watchers.Clear();

            _converters.ForEach(x => x.Dispose());
            _converters.Clear();
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
