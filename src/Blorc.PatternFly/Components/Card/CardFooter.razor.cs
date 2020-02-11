namespace Blorc.PatternFly.Components.Card
{
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public class CardFooterComponent : BlorcComponentBase
    {
        public CardFooterComponent()
        {
            Component = "div";

            CreateConverter()
                .Fixed("pf-c-card__footer")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
