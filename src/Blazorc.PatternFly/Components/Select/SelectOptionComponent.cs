namespace Blazorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Icon;
    using Microsoft.AspNetCore.Components;

    public class SelectOptionComponent : BlazorcComponentBase
    {
        public SelectOptionComponent()
        {
            CreateConverter()
                .Fixed("pf-c-select__menu-item")
                .If(() => IsSelected, "pf-m-selected")
                .Watch(() => IsSelected)
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
        protected bool IsPlaceholder { get; set; }

        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public bool IsSelected => Parent.SelectedItems.ContainsKey(Key);

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Clicked { get; set; }

        protected void OnSelectOptionClick()
        {
            if (!IsSelected)
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
