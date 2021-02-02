namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections.Generic;

    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class ActionColumn : BlorcComponentBase
    {
        public ActionColumn()
        {
            CreateConverter()
                .Fixed(string.Empty)
                .If(() => Align == Align.Center, "pf-m-center")
                .Watch(() => Align)
                .Update(() => Class);
        }

        [Parameter]
        public Func<object, IEnumerable<ActionDefinition>> ActionSource { get; set; }

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
        public ActionColumnType ActionColumnType { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (!string.IsNullOrWhiteSpace(Key))
            {
                if (!ContainerTable.ColumnDefinitions.ContainsKey(Key))
                {
                    ContainerTable.ColumnDefinitions[Key] = new ActionColumnDefinition
                                                            {
                                                                Label = Label, 
                                                                Key = Key, 
                                                                Idx = Idx, 
                                                                ActionSource = ActionSource,
                                                                ActionColumnType = ActionColumnType
                    };
                }
            }
        }
    }
}
