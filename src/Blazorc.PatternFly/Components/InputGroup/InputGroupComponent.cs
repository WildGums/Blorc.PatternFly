namespace Blazorc.PatternFly.Components.InputGroup
{
    using System;
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
