namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class KebabToggleComponent : BlazorcComponentBase
    {
        public KebabToggleComponent()
        {
            Label = "Actions";
            IsPlain = true;
        }

        [Parameter]
        public string Label { get; set; }

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
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }
    }
}
