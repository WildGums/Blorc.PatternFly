namespace Blazorc.PatternFly.Components.Card
{
    using Microsoft.AspNetCore.Components;

    public class CardHeaderComponent : BlazorcComponentBase
    {
        public CardHeaderComponent()
        {
            Component = "div";

            CreateConverter()
                .Fixed("pf-c-card__header")
                .Fixed("pf-c-title")
                .Fixed("pf-m-lg")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
