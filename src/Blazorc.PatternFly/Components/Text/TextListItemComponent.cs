namespace Blazorc.PatternFly.Components.Text
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TextListItemComponent : ComponentBase
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
