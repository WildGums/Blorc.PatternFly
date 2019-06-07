namespace Blazorc.PatternFly.Components.InputGroup
{
    using System;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class InputGroupComponent : BlazorcComponentBase
    {
        public InputGroupComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
