namespace Blazorc.PatternFly.Components.Accordion
{
    using System;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AccordionItemComponent : BlazorcComponentBase
    {
        [Parameter]
        public AccordionComponent Parent { get; set; }

        [Parameter]
        public int Index { get; set; }

        public bool IsSelected => Index == Parent.SelectedIndex;

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public Action<int> ItemClick { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        protected string GetIsExpandedClass()
        {
            return IsSelected ? "pf-m-expanded" : string.Empty;
        }

        protected virtual void OnItemClick()
        {
            Parent.SelectedIndex = Index;
            ItemClick?.Invoke(Index);
        }
    }
}
