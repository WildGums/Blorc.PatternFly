namespace Blorc.PatternFly.Layouts.Flex
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class FlexItemComponent : BlorcComponentBase
    {
        public FlexItemComponent()
        {
            CreateConverter()
                .Fixed("pf-l-flex__item")
                .Watch(() => Spacer)
                .Watch(() => Align)
                .If(() => Align == Align.Default, "")
                .If(() => Align == Align.Right, "pf-m-align-right")
                .If(() => Spacer == Spacer.Default, "")
                .If(() => Spacer == Spacer.None, "pf-m-spacer-none")
                .If(() => Spacer == Spacer.Xs, "pf-m-spacer-xs")
                .If(() => Spacer == Spacer.Sm, "pf-m-spacer-sm")
                .If(() => Spacer == Spacer.Md, "pf-m-spacer-md")
                .If(() => Spacer == Spacer.Lg, "pf-m-spacer-lg")
                .If(() => Spacer == Spacer.Xl, "pf-m-spacer-xl")
                .If(() => Spacer == Spacer.Xxl, "pf-m-spacer-2xl")
                .If(() => Spacer == Spacer.Xxxl, "pf-m-spacer-3xl")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public Spacer Spacer
        {
            get => GetPropertyValue<Spacer>(nameof(Spacer));
            set => SetPropertyValue(nameof(Spacer), value);
        } 
        
        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }

        [Parameter]
        public bool CanGrow
        {
            get => GetPropertyValue<bool>(nameof(CanGrow));
            set => SetPropertyValue(nameof(CanGrow), value);
        }
    }
}
