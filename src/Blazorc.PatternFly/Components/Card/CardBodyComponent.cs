namespace Blazorc.PatternFly.Components.Card
{
    using Blazorc.Components;
    using Blazorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public class CardBodyComponent : BlazorcComponentBase
    {
        public CardBodyComponent()
        {
            Component = "div";

            CreateConverter()
                .Fixed("pf-c-card__footer")
                .If(() => !IsFilled, "pf-m-no-fill")
                .Watch(() => IsFilled)
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string Component { get; set; }

        [Parameter]
        public bool IsFilled { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
