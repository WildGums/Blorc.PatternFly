namespace Blazorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Components;

    public class SelectComponent : BlazorcComponentBase
    {
        private readonly IDictionary<string,string> _selectedItems = new Dictionary<string, string>();

        public SelectComponent()
        {
            Variant = SelectVariant.Single;

            AriaLabelClear = "Clear all";
            ArieLabelToggle = "Options menu";
            AriaLabelRemove = "Remove";

            ToggleId = GenerateUniqueId("pf-toggle-id");

            CreateConverter()
                .Fixed("pf-c-select")
                .If(() => IsExpanded, "pf-m-expanded")
                .Watch(() => IsExpanded)
                .Update(() => Class);
        }

        public string Class
        {
            get;
            set;
        }


        public string WrapperClass
        {
            get
            {
                var items = new List<string>();

                switch (Variant)
                {
                    case SelectVariant.Typeahead:
                        items.Add("pf-m-typeahead");
                        break;

                    case SelectVariant.TypeaheadMulti:
                        items.Add("pf-m-typeahead");
                        break;
                }

                return string.Join(" ", items);
            }
        }

        //public string VariantClass
        //{
        //    get
        //    {
        //        return GetVariantClassName();
        //    }
        //}

        //public string VariantWrapperClass
        //{
        //    get
        //    {
        //        return $"{GetVariantClassName()}-wrapper";
        //    }
        //}


        protected string ToggleId { get; }

        [Parameter] public SelectVariant Variant { get; set; }

        [Parameter]
        public bool IsExpanded
        {
            get => GetPropertyValue<bool>(nameof(IsExpanded));
            set => SetPropertyValue(nameof(IsExpanded), value);
        }

        [Parameter]
        public bool IsGrouped
        {
            get => GetPropertyValue<bool>(nameof(IsGrouped));
            set => SetPropertyValue(nameof(IsGrouped), value);
        }

        [Parameter]
        public string PlaceholderText { get; set; }

        protected RenderFragment PlaceholderItem
        {
            get
            {
                return builder =>
                {
                    builder.OpenComponent(0, typeof(SelectOption));
                    builder.AddAttribute(1, "Key", "-1");
                    builder.AddAttribute(2, "Value", PlaceholderText);
                    builder.AddAttribute(2, "IsPlaceholder", true);
                    builder.AddAttribute(3, "Parent", this);
                    builder.CloseComponent();
                };
            }
        }


        public IReadOnlyDictionary<string, string> SelectedItems => (IReadOnlyDictionary<string, string>)_selectedItems;

        [Parameter] public string Label { get; set; }

        [Parameter] public string AriaLabelledBy { get; set; }

        [Parameter] public string AriaLabelTypeAhead { get; set; }

        [Parameter] public string AriaLabelClear { get; set; }

        [Parameter] public string ArieLabelToggle { get; set; }

        [Parameter] public string AriaLabelRemove { get; set; }

        [Parameter] public string Width { get; set; }

        [Parameter]
        public RenderFragment Items { get; set; }

        [Parameter]
        public EventHandler<EventArgs> SelectionChanged { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Cleared { get; set; }

        public string Text
        {
            get
            {
                if (SelectedItems.Count == 0)
                {
                    return PlaceholderText;
                }

                if (Variant == SelectVariant.Single)
                {
                    return SelectedItems.FirstOrDefault().Value;
                }

                return string.Empty;
            }
        }

        protected void Toggle()
        {
            IsExpanded = !IsExpanded;
        }

        public void SelectItem(string key, string value)
        {
            if (Variant == SelectVariant.Single)
            {
                _selectedItems.Clear();
            }

            _selectedItems.Add(key, value);
            Toggle();
        }

        public void UnselectItem(string key)
        {
            _selectedItems.Remove(key);
            Toggle();
        }
    }
}
