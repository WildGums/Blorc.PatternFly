namespace Blorc.StateConverters
{
    using System;
    using System.ComponentModel;

    public class PropertyStateWatcher : StateWatcherBase
    {
        private readonly string _propertyName;

        private object _source;
        private INotifyPropertyChanged _notifyPropertyChangedSource;

        public PropertyStateWatcher(object source, string propertyName)
        {
            _source = source;
            _propertyName = propertyName;

            _notifyPropertyChangedSource = source as INotifyPropertyChanged;
            if (_notifyPropertyChangedSource != null)
            {
                _notifyPropertyChangedSource.PropertyChanged += OnPropertyChanged;
            }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.PropertyName) || e.PropertyName.Equals(_propertyName))
            {
                //Log.Debug($"Property '{e.PropertyName}' has changed");

                RaiseStateChanged();
            }
        }

        protected override void DisposeManaged()
        {
            if (_notifyPropertyChangedSource != null)
            {
                _notifyPropertyChangedSource.PropertyChanged -= OnPropertyChanged;
            }

            _source = null;
            _notifyPropertyChangedSource = null;

            base.DisposeManaged();
        }
    }
}
