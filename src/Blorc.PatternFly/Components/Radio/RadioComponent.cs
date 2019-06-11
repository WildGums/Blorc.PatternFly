namespace Blorc.PatternFly.Components.Radio
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class RadioComponent : UniqueComponentBase
    {
        public RadioComponent()
        {
            IsValid = true;
        }

        public override string ComponentName => "radio";

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
        public object Value { get; set; }

        [Parameter]
        public EventHandler<EventArgs> OnChange { get; set; }
    }
}
