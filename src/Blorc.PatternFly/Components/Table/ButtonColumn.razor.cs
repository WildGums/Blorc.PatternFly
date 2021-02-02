namespace Blorc.PatternFly.Components.Table
{
    using System;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Button;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class ButtonColumn : BlorcComponentBase
    {
        public ButtonColumn()
        {
            CreateConverter()
                .Fixed(string.Empty)
                .If(() => Align == Align.Center, "pf-m-center")
                .Watch(() => Align)
                .Update(() => Class);
        }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }

        public string Class { get; set; }

        [CascadingParameter]
        public Table ContainerTable { get; set; }

        [Parameter]
        public int Idx { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public ButtonVariant Variant { get; set; }

        [Parameter]
        public Action<object> Action { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (!string.IsNullOrWhiteSpace(Key))
            {
                if (!ContainerTable.ColumnDefinitions.ContainsKey(Key))
                {
                    ContainerTable.ColumnDefinitions[Key] = new ButtonColumnDefinition
                                                            {
                                                                Label = Label, Key = Key, Idx = Idx, Variant = Variant, Action = Action
                                                            };
                }
            }
        }
    }
}
