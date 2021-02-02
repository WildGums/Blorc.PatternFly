namespace Blorc.PatternFly.Components.Title
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class Title : BlorcComponentBase
    {
        public Title()
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
