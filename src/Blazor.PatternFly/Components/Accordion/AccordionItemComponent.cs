namespace Blazor.PatternFly.Components.Accordion
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class AccordionItemComponent : ComponentBase
    {
        public const string ButtonExpandedClass = "pf-c-accordion__toggle pf-m-expanded";

        public const string ButtonCollapsedClass = "pf-c-accordion__toggle";

        public const string BodyExpandedClass = "pf-c-accordion__expanded-content pf-m-expanded";

        public const string BodyCollapsedClass = "pf-c-accordion__expanded-content";

        [Parameter] public AccordionComponent Parent { get; set; }

        [Parameter] public int Index { get; set; }

        public bool IsSelected => Index == Parent.SelectedIndex;

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public Action<int> ItemClick { get; set; }

        [Parameter]
        public RenderFragment ExpandedContentBody { get; set; }

        protected virtual void OnItemClick()
        {
            Parent.SelectedIndex = Index;
            ItemClick?.Invoke(Index);
        }
    }
}
