namespace Blazorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Icon;
    using Microsoft.AspNetCore.Components;

    public class SelectOptionComponent : ComponentBase
    {
        public SelectOptionComponent()
        {
        }

        [Parameter]
        public SelectComponent Parent { get; set; }

        public string Class
        {
            get
            {
                var items = new List<string>();
                if (IsSelected)
                {
                    items.Add("pf-m-selected");
                }

                return string.Join(" ", items);
            }
        }

        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool IsPlaceholder { get; set; }

        public bool IsSelected
        {
            get
            {
                var item = Parent.SelectedItems.OfType<Tuple<string, string>>().FirstOrDefault(tuple => tuple.Item1 == Key);
                return item != null;
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

        protected void OptionClicked()
        {
            if (!IsSelected)
            {
                Parent.SelectItem(Key, Value);
            }
            else
            {
                Parent.UnselectItem(Key);
            }
        }
    }
}
