namespace Blazorc.PatternFly.Components.Text
{
    using System;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TextListItemComponent : BlazorcComponentBase
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
