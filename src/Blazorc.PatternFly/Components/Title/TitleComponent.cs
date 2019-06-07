namespace Blazorc.PatternFly.Components.Title
{
    using System;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TitleComponent : BlazorcComponentBase
    {
        public TitleComponent()
        {
            Size = "xl";
            HeadingLevel = "h1";
        }

        [Parameter]
        public string Size { get; set; }

        [Parameter]
        public string HeadingLevel { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
