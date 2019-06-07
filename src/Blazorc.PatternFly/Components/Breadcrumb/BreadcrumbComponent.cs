namespace Blazorc.PatternFly.Components.Breadcrumb
{
    using System;
    using System.Collections.Generic;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class BreadcrumbComponent : BlazorcComponentBase
    {
        public BreadcrumbComponent()
        {
            Label = "Breadcrumb";
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
