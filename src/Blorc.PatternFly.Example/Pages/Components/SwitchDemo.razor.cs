namespace Blorc.PatternFly.Example.Pages.Components
{
    using System.ComponentModel;

    using Blorc.Components;

    public class SwitchDemoComponent : BlorcComponentBase
    {
        protected bool SimpleSwitchIsChecked
        {
            get
            {
                return GetPropertyValue<bool>(nameof(SimpleSwitchIsChecked));
            }

            set
            {
                SetPropertyValue(nameof(SimpleSwitchIsChecked), value);
            }
        }

        protected string SimpleSwitchLabel
        {
            get
            {
                return SimpleSwitchIsChecked ? "Message when on" : "Message when off";
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SimpleSwitchIsChecked))
            {
                StateHasChanged();
            }
        }
    }
}
