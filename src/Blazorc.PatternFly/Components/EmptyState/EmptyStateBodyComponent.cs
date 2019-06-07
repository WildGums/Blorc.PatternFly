﻿namespace Blazorc.PatternFly.Components.EmptyState
{
    using System;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class EmptyStateBodyComponent : BlazorcComponentBase
    {
        public EmptyStateBodyComponent()
        {
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
