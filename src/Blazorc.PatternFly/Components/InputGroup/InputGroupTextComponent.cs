﻿namespace Blazorc.PatternFly.Components.InputGroup
{
    using System;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class InputGroupTextComponent : BlazorcComponentBase
    {
        public InputGroupTextComponent()
        {
            Component = "span";
        }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string HtmlFor { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
