namespace Blorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class Item : BlorcComponentBase
    {
        public Item()
        {
            Component = "a";
            Href = "#";
        }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsHovered { get; set; }

        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
