namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class DropdownItemComponent : BlazorcComponentBase
    {
        public DropdownItemComponent()
        {
            Component = "a";
            Index = -1;
        }

        public string Class { get; set; }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsHovered { get; set; }

        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> SelectionChanged { get; set; }
    }
}
