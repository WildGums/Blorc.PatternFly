namespace Blazorc.PatternFly.Components.Text
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TextListComponent : ComponentBase
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
