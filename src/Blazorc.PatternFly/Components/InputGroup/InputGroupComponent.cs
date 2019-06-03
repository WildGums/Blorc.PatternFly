namespace Blazorc.PatternFly.Components.InputGroup
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class InputGroupComponent : ComponentBase
    {
        public InputGroupComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
