namespace Blorc.Components
{
    using System.ComponentModel;

    public abstract partial class BlorcComponentBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TValue GetPropertyValue<TValue>(string propertyName)
        {
            return _propertyBag.GetPropertyValue<TValue>(propertyName, default(TValue));
        }

        public void SetPropertyValue(string propertyName, object value)
        {
            _propertyBag.SetPropertyValue(propertyName, value);
        }

        private void OnPropertyBagPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e);
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {

        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaisePropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            OnPropertyChanged(eventArgs);

            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
