namespace Blorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Blorc.Components;
    using Blorc.StateConverters;
    using Icon;
    using Microsoft.AspNetCore.Components;

    public class SelectOptionComponent : BlorcComponentBase
    {
        public SelectOptionComponent()
        {
            CreateConverter()
                .Fixed("pf-c-select__menu-item")
                .If(() => IsSelected, "pf-m-selected")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsSelected)
                .Watch(() => IsDisabled)
                .Update(() => Class);
        }

        [CascadingParameter]
        public SelectComponent ContainerSelect { get; set; }

        public string Class
        {
            get;
            set;
        }

        [Parameter]
        public bool IsPlaceholder { get; set; }

        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public bool IsSelected => ContainerSelect != null && ContainerSelect.SelectedItems.Contains(Key);

        public bool IsVisible
        {
            get
            {
                if (ContainerSelect.Variant == SelectVariant.Typeahead || ContainerSelect.Variant == SelectVariant.TypeaheadMulti)
                {
                    return string.IsNullOrWhiteSpace(ContainerSelect.FilterText) || ContainerSelect != null && 
                           (ContainerSelect.TypeaheadMatchExpression?.Invoke(ContainerSelect.FilterText, Value) ?? Value.StartsWith(ContainerSelect.FilterText, StringComparison.InvariantCultureIgnoreCase));
                }

                return true;
            }
        }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Clicked { get; set; }

        protected void OptionClick()
        {
            if (IsPlaceholder)
            {
                ContainerSelect.ClearSelection();
            }
            else if (!IsSelected)
            {
                ContainerSelect.SelectItem(Key);
            }
            else
            {
                ContainerSelect.UnselectItem(Key);
            }

            RaisePropertyChanged(nameof(IsSelected));

            Clicked?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (ContainerSelect != null && !string.IsNullOrWhiteSpace(Key))
            {
                ContainerSelect.Values[Key] = Value;
            }
        }
    }
}
