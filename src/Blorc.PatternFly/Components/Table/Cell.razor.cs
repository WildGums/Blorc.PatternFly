namespace Blorc.PatternFly.Components.Table
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public partial class Cell : BlorcComponentBase
    {
        public Cell()
        {
            CreateConverter()
                .Fixed("")
                .If(() => Align == Align.Center, "pf-m-center")
                .Watch(() => Align)
                .Update(() => Class);
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public RenderFragment ValueContent { get; set; }

        public string Class { get; set; }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }
    }
}
