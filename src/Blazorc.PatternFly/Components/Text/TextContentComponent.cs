namespace Blazorc.PatternFly.Components.Text
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TextContentComponent : BlazorcComponentBase
    {
        public TextContentComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
