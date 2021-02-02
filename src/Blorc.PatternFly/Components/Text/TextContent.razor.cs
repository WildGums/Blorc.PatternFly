namespace Blorc.PatternFly.Components.Text
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class TextContent : BlorcComponentBase
    {
        public TextContent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
