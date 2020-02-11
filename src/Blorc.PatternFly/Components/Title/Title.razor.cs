namespace Blorc.PatternFly.Components.Title
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TitleComponent : BlorcComponentBase
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
