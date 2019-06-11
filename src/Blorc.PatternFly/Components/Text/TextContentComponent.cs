namespace Blorc.PatternFly.Components.Text
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class TextContentComponent : BlorcComponentBase
    {
        public TextContentComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
