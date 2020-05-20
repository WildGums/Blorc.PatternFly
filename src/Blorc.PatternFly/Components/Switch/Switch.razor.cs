namespace Blorc.PatternFly.Components.Switch
{
    using System;
    using System.ComponentModel;

    using Blorc.Components;
    using Blorc.Reflection;

    using Microsoft.AspNetCore.Components;

    public class SwitchComponent : UniqueComponentBase
    {
        public override string ComponentName => "switch";

        [Parameter]
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

        [Parameter]
        public bool IsDisabled
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsDisabled));
            }

            set
            {
                SetPropertyValue(nameof(IsDisabled), value);
            }
        }

        [Parameter]
        public string Label
        {
            get
            {
                return GetPropertyValue<string>(nameof(Label));
            }

            set
            {
                SetPropertyValue(nameof(Label), value);
            }
        }

        [Parameter]
        public EventCallback<bool> OnChange { get; set; }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsChecked))
            {
                OnChange.InvokeAsync(IsChecked);
            }

            // StateHasChanged();
        }

        protected void OnValueChanged(ChangeEventArgs e)
        {
            IsChecked = (bool)e.Value;
        }

    }
}
