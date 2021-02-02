namespace Blorc.PatternFly.Components.Breadcrumb
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class Breadcrumb : BlorcComponentBase
    {
        public Breadcrumb()
        {
            Label = "Breadcrumb";
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
