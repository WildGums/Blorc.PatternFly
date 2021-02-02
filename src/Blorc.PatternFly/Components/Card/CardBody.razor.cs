namespace Blorc.PatternFly.Components.Card
{
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public partial class CardBody : BlorcComponentBase
    {
        public CardBody()
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
