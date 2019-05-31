namespace Blazorc.PatternFly.Components.Title
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TitleComponent : ComponentBase
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
