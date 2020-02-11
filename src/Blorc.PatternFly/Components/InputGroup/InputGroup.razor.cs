namespace Blorc.PatternFly.Components.InputGroup
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class InputGroupComponent : BlorcComponentBase
    {
        public InputGroupComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
