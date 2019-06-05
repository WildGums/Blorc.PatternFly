namespace Blazorc.PatternFly.Components.Text
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TextComponent : BlazorcComponentBase
    {
        public TextComponent()
        {
            Component = "p";
        }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
