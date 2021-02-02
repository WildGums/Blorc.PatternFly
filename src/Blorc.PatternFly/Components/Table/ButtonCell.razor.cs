namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Button;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class ButtonCell : BlorcComponentBase
    {
        public ButtonCell()
        {
            CreateConverter()
                .Fixed(string.Empty)
                .If(() => Align == Align.Center, "pf-m-center")
                .Watch(() => Align)
                .Update(() => Class);
        }

        [Parameter]
        public Action Action { get; set; }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }

        public string Class { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public ButtonVariant Variant { get; set; }
    }
}
