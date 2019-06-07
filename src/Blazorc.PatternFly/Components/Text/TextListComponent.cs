namespace Blazorc.PatternFly.Components.Text
{
    using System;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TextListComponent : BlazorcComponentBase
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
