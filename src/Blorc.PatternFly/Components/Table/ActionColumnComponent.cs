namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class ActionColumnComponent : BlorcComponentBase
    {
        public ActionColumnComponent()
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

        public string Class { get; set; }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }

        [CascadingParameter]
        public TableComponent ContainerTable { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (!string.IsNullOrWhiteSpace(Key))
            {
                ContainerTable.ColumnDefinitions[Key] = new ActionColumnDefinition
                {
                    Label = Label, 
                    Key = Key,
                    Idx = Idx,
                    ActionSource = ActionSource
                };
            }
        }

        [Parameter]
        public int Idx { get; set; }
        
        [Parameter]
        public Func<object, IEnumerable<ActionDefinition>> ActionSource { get; set; }
    }
}
