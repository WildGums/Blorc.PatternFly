namespace Blorc.PatternFly.Components.Text
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TextListComponent : BlorcComponentBase
    {
        public TextListComponent()
        {
            Component = "ul";
        }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
