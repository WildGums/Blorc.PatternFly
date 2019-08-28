namespace Blorc.PatternFly.Components.Checkbox
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class CheckboxComponent : UniqueComponentBase
    {
        public CheckboxComponent()
        {
            IsValid = true;
        }

        public override string ComponentName => "checkbox";

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsValid { get; set; }

        public bool IsInvalid
        {
            get { return !IsValid; }
        }

        [Parameter]
        public bool IsChecked { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public EventHandler<EventArgs> OnChange { get; set; }

        protected void OnValueChanged(UIChangeEventArgs e)
        {
            IsChecked = (bool)e.Value;

            var handler = OnChange;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }
}
