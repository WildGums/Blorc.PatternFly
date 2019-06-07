namespace Blazorc.PatternFly.Components.EmptyState
{
    using System;
    using System.Collections.Generic;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class EmptyStateComponent : BlazorcComponentBase
    {
        public EmptyStateComponent()
        {
            Variant = EmptyStateVariant.Large;
        }

        public string Class
        {
            get
            {
                var items = new List<string>();

                switch (Variant)
                {
                    case EmptyStateVariant.Small:
                        items.Add("pf-m-sm");
                        break;

                    case EmptyStateVariant.Large:
                        items.Add("pf-m-lg");
                        break;
                }

                return string.Join(" ", items);
            }
        }

        [Parameter]
        public EmptyStateVariant Variant { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
