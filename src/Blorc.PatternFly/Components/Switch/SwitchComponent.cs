namespace Blorc.PatternFly.Components.Switch
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class SwitchComponent : UniqueComponentBase
    {
        public SwitchComponent()
        {
            IsChecked = true;
        }

        public override string ComponentName => "switch";

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsChecked { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public Action OnChange { get; set; }

        public void SetLabel(string text)
        {
            Label = text;
        }
    }
}
