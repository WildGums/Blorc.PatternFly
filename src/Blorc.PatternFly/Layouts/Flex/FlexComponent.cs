namespace Blorc.PatternFly.Layouts.Flex
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class FlexComponent : BlorcComponentBase
    {
        public FlexComponent()
        {
            CreateConverter()
                .Fixed("pf-l-flex")
                .Watch(() => CanGrow)
                .Watch(() => FlexModifier)
                .Watch(() => Align)
                .Watch(() => IsColumn)
                .Watch(() => IsRowOnLg)
                .Watch(() => ContentJustification)
                .If(() => CanGrow, "pf-m-grow")
                .If(() => IsColumn, "pf-m-column")
                .If(() => IsRowOnLg, "pf-m-row-on-lg")
                .If(() => ContentJustification == ContentJustification.Default, "")
                .If(() => ContentJustification == ContentJustification.FlexEnd, "pf-m-justify-content-flex-end")
                .If(() => ContentJustification == ContentJustification.SpaceBetween, "pf-m-justify-content-space-between")
                .If(() => ContentJustification == ContentJustification.FlexStart, "pf-m-justify-content-flex-start")
                .If(() => Align == Align.Default, "")
                .If(() => Align == Align.Right, "pf-m-align-right")
                .If(() => Align == Align.SelfFlexEnd, "pf-m-align-self-flex-end")
                .If(() => Align == Align.SelfCenter, "pf-m-align-self-center")
                .If(() => Align == Align.SelfBaseline, "pf-m-align-self-baseline")
                .If(() => Align == Align.SelfStretch, "pf-m-align-self-stretch")
                .If(() => FlexModifier == FlexModifier.Default, "")
                .If(() => FlexModifier == FlexModifier.Flex1, " pf-m-flex-1")
                .If(() => FlexModifier == FlexModifier.Flex2, " pf-m-flex-2")
                .If(() => FlexModifier == FlexModifier.Flex3, " pf-m-flex-3")
                .If(() => CanGrow, "pf-m-grow")
                .Update(() => Class);
        }

        [Parameter]
        public bool IsRowOnLg
        {
            get => GetPropertyValue<bool>(nameof(IsRowOnLg));
            set => SetPropertyValue(nameof(IsRowOnLg), value);
        }

        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool CanGrow
        {
            get => GetPropertyValue<bool>(nameof(CanGrow));
            set => SetPropertyValue(nameof(CanGrow), value);
        }

        [Parameter]
        public bool IsColumn
        {
            get => GetPropertyValue<bool>(nameof(IsColumn));
            set => SetPropertyValue(nameof(IsColumn), value);
        }

        [Parameter]
        public FlexModifier FlexModifier
        {
            get => GetPropertyValue<FlexModifier>(nameof(FlexModifier));
            set => SetPropertyValue(nameof(FlexModifier), value);
        }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        } 
        
        [Parameter]
        public ContentJustification ContentJustification
        {
            get => GetPropertyValue<ContentJustification>(nameof(ContentJustification));
            set => SetPropertyValue(nameof(ContentJustification), value);
        }
    }
}
