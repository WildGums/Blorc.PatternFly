namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class ToggleContainerComponent : BlazorcComponentBase
    {
        public ToggleContainerComponent()
        {
            CreateConverter()
                .Fixed("pf-c-dropdown__toggle")
                .If(() => IsPlain, "pf-m-plain")
                .Watch(() => IsPlain)
                .Update(() => ButtonClass);
        }

        public string ButtonClass { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public bool IsOpen { get; set; }

        [Parameter]
        public bool IsFocused { get; set; }

        [Parameter]
        public bool IsHovered { get; set; }

        [Parameter]
        public bool IsActive { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsPlain { get; set; }

        [Parameter]
        public bool IsSplitButton { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }
    }
}
