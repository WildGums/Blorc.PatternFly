namespace Blazorc.PatternFly.Components.Card
{
    using Microsoft.AspNetCore.Components;

    public class CardFooterComponent : BlazorcComponentBase
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
