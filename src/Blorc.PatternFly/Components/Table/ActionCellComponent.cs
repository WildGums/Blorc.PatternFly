namespace Blorc.PatternFly.Components.Table
{
    using System;
    using Blorc.Components;
    using Dropdown;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class ActionCellComponent : BlorcComponentBase
    {
        public ActionCellComponent()
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
        public RenderFragment ChildContent { get; set; }

        public string Class { get; set; }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }
    }
}
