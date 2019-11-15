namespace Blorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public class SelectComponent : BlorcComponentBase
    {
        private readonly Dictionary<string, string> _selectedItems = new Dictionary<string, string>();

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

        protected string ToggleId { get; }

        [Parameter] public SelectVariant Variant { get; set; }

        [Parameter]
        public bool IsExpanded
        {
            get => GetPropertyValue<bool>(nameof(IsExpanded));
            set => SetPropertyValue(nameof(IsExpanded), value);
        }

        public string FilterText
        {
            get => GetPropertyValue<string>(nameof(FilterText));
            set => SetPropertyValue(nameof(FilterText), value);
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
                    builder.CloseComponent();
                };
            }
        }

//        protected override void OnAfterRender(bool firstRender)
//        {
//            base.OnAfterRender(firstRender);
//            if (firstRender)
//            {
//                // Required to ensure binding
//                // RaisePropertyChanged(nameof(SelectedItems));
//            }
//        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (SelectedItems == null)
            {
                SelectedItems = new ObservableCollection<string>();
            }
        }

        public Dictionary<string, string> Values { get; } = new Dictionary<string, string>();

        [Parameter]
        public ObservableCollection<string> SelectedItems
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems));
            set => SetPropertyValue(nameof(SelectedItems), value);
        }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string AriaLabelledBy { get; set; }

        [Parameter]
        public string AriaLabelTypeAhead { get; set; }

        [Parameter]
        public string AriaLabelClear { get; set; }

        [Parameter]
        public string ArieLabelToggle { get; set; }

        [Parameter]
        public string AriaLabelRemove { get; set; }

        [Parameter]
        public string Width { get; set; }

        [Parameter]
        public RenderFragment Items { get; set; }

        [Parameter]
        public EventCallback<ObservableCollection<string>> SelectedItemsChanged { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Cleared { get; set; }

        public string Text
        {
            get
            {
                if (Variant == SelectVariant.Checkbox)
                {
                    return PlaceholderText;
                }

                if (Variant == SelectVariant.Single && SelectedItems.Count == 0)
                {
                    return PlaceholderText;
                }

                if (Variant == SelectVariant.Single || Variant == SelectVariant.Typeahead || Variant == SelectVariant.TypeaheadMulti)
                {
                    var selectedKey = SelectedItems.FirstOrDefault();
                    if (selectedKey != null && Values.TryGetValue(selectedKey, out var selectedValue))
                    {
                        return selectedValue;
                    }
                }

                return string.Empty;
            }
        }


        protected void Toggle()
        {
            IsExpanded = !IsExpanded;
        }

        public void SelectItem(string key)
        {
            if (Variant == SelectVariant.Single || Variant == SelectVariant.Typeahead)
            {
                SelectedItems.Clear();
            }

            SelectedItems.Add(key);

            // TODO: review if this is required
            RaisePropertyChanged(nameof(SelectedItems));

            if (Variant == SelectVariant.Single || Variant == SelectVariant.Typeahead)
            {
                Toggle();
            }
            else
            {
                StateHasChanged();
            }
        }

        public void UnselectItem(string key)
        {
            if (SelectedItems.Remove(key))
            {
                // TODO: review if this is required
                RaisePropertyChanged(nameof(SelectedItems));
            }

            if (Variant == SelectVariant.Single)
            {
                Toggle();
            }
            else
            {
                StateHasChanged();
            }
        }

        public void ClearSelection(bool toggle = true)
        {
            SelectedItems.Clear();

            // TODO: review if this is required
            RaisePropertyChanged(nameof(SelectedItems));

            if (toggle)
            {
                Toggle();
            }

            if (Variant == SelectVariant.Typeahead || Variant == SelectVariant.TypeaheadMulti)
            {
                FilterText = string.Empty;
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if ((Variant == SelectVariant.Typeahead || Variant == SelectVariant.TypeaheadMulti) && e.PropertyName == nameof(FilterText))
            {
                StateHasChanged();
            }
        }

        protected void OnFilterInput(ChangeEventArgs e)
        {
            FilterText = (string)e.Value;
        }

        protected void UnselectFirstItem()
        {
            var firstOrDefault = SelectedItems.FirstOrDefault();
            UnselectItem(firstOrDefault);
        }

        protected void ButtonClick()
        {
            ClearSelection(false);
        }

        [Parameter]
        public Func<string, string, bool> TypeaheadMatchExpression { get; set; }
    }
}
