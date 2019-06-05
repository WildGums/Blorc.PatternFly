namespace Blazorc.PatternFly.Components.Select
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class CheckboxSelectComponent : BlazorcComponentBase
    {
        public CheckboxSelectComponent()
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
        public bool IsExpanded { get; set; }

        [Parameter]
        public bool IsGrouped { get; set; }

        [Parameter]
        public List<object> CheckedItems {get;set;}

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
