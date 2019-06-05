namespace Blazorc.PatternFly.Components.Breadcrumb
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class BreadcrumbItemComponent : BlazorcComponentBase
    {
        public BreadcrumbItemComponent()
        {
            Component = "a";
        }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public bool IsActive { get; set; }

        [Parameter]
        public string To { get; set; }

        [Parameter]
        public string Target { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
