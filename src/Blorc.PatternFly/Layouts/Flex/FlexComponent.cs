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
                .Watch(() => FlexType)
                .Watch(() => Align)
                .Watch(() => IsColumn)
                .Watch(() => IsRowOnLarge)
                .Watch(() => ContentJustification)
                .If(() => CanGrow, "pf-m-grow")
                .If(() => IsColumn, "pf-m-column")
                .If(() => IsRowOnLarge, "pf-m-row-on-lg")
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
                .If(() => FlexType == FlexType.Default, "")
                .If(() => FlexType == FlexType.Flex1, " pf-m-flex-1")
                .If(() => FlexType == FlexType.Flex2, " pf-m-flex-2")
                .If(() => FlexType == FlexType.Flex3, " pf-m-flex-3")
                .If(() => CanGrow, "pf-m-grow")
                .Update(() => Class);
        }

        [Parameter]
        public bool IsRowOnLarge
        {
            get => GetPropertyValue<bool>(nameof(IsRowOnLarge));
            set => SetPropertyValue(nameof(IsRowOnLarge), value);
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
        public FlexType FlexType
        {
            get => GetPropertyValue<FlexType>(nameof(FlexType));
            set => SetPropertyValue(nameof(FlexType), value);
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
