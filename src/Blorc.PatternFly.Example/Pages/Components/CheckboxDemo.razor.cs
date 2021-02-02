namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.ComponentModel;

    using Blorc.Components;

    public partial class CheckboxDemo : BlorcComponentBase
    {
        public bool IsChecked
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsChecked));
            }

            set
            {
                SetPropertyValue(nameof(IsChecked), value);
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(IsChecked))
            {
                Console.WriteLine("IsChecked Changed => " + IsChecked);
            }
        }
    }
}
