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

        [Parameter]
        public SelectComponent Parent { get; set; }

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

        public bool IsSelected => Parent != null && Parent.SelectedItems.ContainsKey(Key);

        public bool IsVisible
        {
            get
            {
                if (Parent.Variant == SelectVariant.Typeahead || Parent.Variant == SelectVariant.TypeaheadMulti)
                {
                    return string.IsNullOrWhiteSpace(Parent.FilterText) || Parent != null && Value.StartsWith(Parent.FilterText);
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
                Parent.ClearSelection();
            }
            else if (!IsSelected)
            {
                Parent.SelectItem(Key, Value);
            }
            else
            {
                Parent.UnselectItem(Key);
            }

            RaisePropertyChanged(nameof(IsSelected));

            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
