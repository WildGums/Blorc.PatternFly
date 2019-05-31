namespace Blazorc.PatternFly.Components.Switch
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class SwitchComponent : ComponentBase
    {
        public SwitchComponent()
        {
            IsChecked = true;
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsChecked { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public Action OnChange { get; set; }
    }
}
