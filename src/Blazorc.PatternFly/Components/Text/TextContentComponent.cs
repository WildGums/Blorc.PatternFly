namespace Blazorc.PatternFly.Components.Text
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TextContentComponent : ComponentBase
    {
        public TextContentComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
