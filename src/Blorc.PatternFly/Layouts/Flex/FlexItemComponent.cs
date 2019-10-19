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
                .Watch(() => Space)
                .Watch(() => Align)
                .If(() => Align == Align.Default, "")
                .If(() => Align == Align.Right, "pf-m-align-right")
                .If(() => Space == Space.Default, "")
                .If(() => Space == Space.None, "pf-m-spacer-none")
                .If(() => Space == Space.VerySmall, "pf-m-spacer-xs")
                .If(() => Space == Space.Small, "pf-m-spacer-sm")
                .If(() => Space == Space.Medium, "pf-m-spacer-md")
                .If(() => Space == Space.Large, "pf-m-spacer-lg")
                .If(() => Space == Space.VeryLarge, "pf-m-spacer-xl")
                .If(() => Space == Space.VeryLargeX2, "pf-m-spacer-2xl")
                .If(() => Space == Space.VeryLargeX3, "pf-m-spacer-3xl")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public Space Space
        {
            get => GetPropertyValue<Space>(nameof(Space));
            set => SetPropertyValue(nameof(Space), value);
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
