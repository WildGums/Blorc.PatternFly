namespace Blorc.PatternFly.Components.Checkbox
{
    using System.ComponentModel;

    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public partial class Checkbox : UniqueComponentBase
    {
        public Checkbox()
        {
            IsValid = true;
        }

        public override string ComponentName => "checkbox";

        [Parameter]
        public bool IsChecked
        {
            get { return GetPropertyValue<bool>(nameof(IsChecked)); }
            set { SetPropertyValue(nameof(IsChecked), value); }
        }

        [Parameter]
        public bool IsDisabled { get; set; }

        public bool IsInvalid
        {
            get { return !IsValid; }
        }

        [Parameter]
        public bool IsValid { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public EventCallback<bool> OnChange { get; set; }

        protected void OnValueChanged(ChangeEventArgs e)
        {
            IsChecked = (bool)e.Value;
            OnChange.InvokeAsync(IsChecked);
        }
    }
}
