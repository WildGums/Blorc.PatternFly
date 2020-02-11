namespace Blorc.PatternFly.Components.Text
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TextListItemComponent : BlorcComponentBase
    {
        public TextListItemComponent()
        {
            Component = "li";
        }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
