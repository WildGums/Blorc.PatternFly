namespace Blorc.PatternFly.Components.Breadcrumb
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class BreadcrumbComponent : BlorcComponentBase
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
