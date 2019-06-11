namespace Blorc.PatternFly.Components.Text
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TextComponent : BlorcComponentBase
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
