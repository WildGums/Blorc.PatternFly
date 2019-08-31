namespace Blorc.PatternFly.Components.Accordion
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AccordionItemComponent : BlorcComponentBase
    {
        [CascadingParameter]
        public AccordionComponent ContainerAccordion { get; set; }

        [Parameter]
        public int Index { get; set; }

        public bool IsSelected => Index == ContainerAccordion.SelectedIndex;

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
            ContainerAccordion.SelectedIndex = Index;
            ItemClick?.Invoke(Index);
        }
    }
}
