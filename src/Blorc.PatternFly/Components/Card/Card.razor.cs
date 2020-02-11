namespace Blorc.PatternFly.Components.Card
{
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public class CardComponent : BlorcComponentBase
    {
        public CardComponent()
        {
            Component = "article";

            CreateConverter()
                .Fixed("pf-c-card")
                .If(() => IsHoverable, "pf-m-hoverable")
                .Watch(() => IsHoverable)
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public bool IsHoverable { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
