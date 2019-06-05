namespace Blazorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class CheckboxSelectGroupComponent : BlazorcComponentBase
    {
        public CheckboxSelectGroupComponent()
        {

        }

        public string Class
        {
            get
            {
                var items = new List<string>();


                return string.Join(" ", items);
            }
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
