namespace Blorc.PatternFly.Components.InputGroup
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class InputGroup : BlorcComponentBase
    {
        public InputGroup()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
