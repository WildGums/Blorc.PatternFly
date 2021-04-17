namespace Blorc.PatternFly.Components.Select

{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;

    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class Select : BlorcComponentBase
    {
        private readonly Dictionary<string, string> _selectedItems = new Dictionary<string, string>();

        public Select()
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

        [Parameter]
        public string AriaLabelClear { get; set; }

        [Parameter]
        public string AriaLabelledBy { get; set; }

        [Parameter]
        public string AriaLabelRemove { get; set; }

        [Parameter]
        public string AriaLabelTypeAhead { get; set; }

        [Parameter]
        public string ArieLabelToggle { get; set; }

        public string Class
        {
            get;
            set;
        }

        [Parameter]
        public EventHandler<EventArgs> Cleared { get; set; }

        [Parameter]
        public IEnumerable DataSource
        {
            get => GetPropertyValue<IEnumerable>(nameof(DataSource));
            set => SetPropertyValue(nameof(DataSource), value);
        }

        public string FilterText
        {
            get => GetPropertyValue<string>(nameof(FilterText));
            set => SetPropertyValue(nameof(FilterText), value);
        }

        [Parameter]
        public Func<object, string> GroupFunc { get; set; }

        [Parameter]
        public bool IsExpanded
        {
            get => GetPropertyValue<bool>(nameof(IsExpanded));
            set => SetPropertyValue(nameof(IsExpanded), value);
        }

        [Parameter]
        public EventCallback<bool> IsExpandedChanged { get; set; }

        [Parameter]
        public bool IsGrouped
        {
            get => GetPropertyValue<bool>(nameof(IsGrouped));
            set => SetPropertyValue(nameof(IsGrouped), value);
        }

        [Parameter]
        public RenderFragment Items { get; set; }

        [Parameter]
        public Func<object, string> KeyFunc { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string PlaceholderText { get; set; }

        [Parameter]
        public ObservableCollection<string> SelectedItems
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems));
            set => SetPropertyValue(nameof(SelectedItems), value);
        }

        [Parameter]
        public EventCallback<ObservableCollection<string>> SelectedItemsChanged { get; set; }

        public string Text
        {
            get
            {
                if (Variant == SelectVariant.Checkbox)
                {
                    return PlaceholderText;
                }

                if (Variant == SelectVariant.Single)
                {
                    if (SelectedItems.Count == 0)
                    {
                        return PlaceholderText;
                    }

                    var selectedKey = SelectedItems.FirstOrDefault();
                    if (selectedKey is not null && Values.TryGetValue(selectedKey, out var selectedValue))
                    {
                        return selectedValue;
                    }
                }

                if (Variant == SelectVariant.Single || Variant == SelectVariant.Typeahead || Variant == SelectVariant.TypeaheadMulti)
                {
                    var selectedKey = SelectedItems.FirstOrDefault();
                    if (selectedKey is not null && Values.TryGetValue(selectedKey, out var selectedValue))
                    {
                        return selectedValue;
                    }
                }

                return string.Empty;
            }
        }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }

        [Parameter]
        public Func<string, string, bool> TypeaheadMatchExpression { get; set; }

        [Parameter]
        public Func<object, string> ValueFunc { get; set; }

        public Dictionary<string, string> Values { get; } = new Dictionary<string, string>();

        [Parameter]
        public SelectVariant Variant { get; set; }

        [Parameter]
        public string Width { get; set; }

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

        protected string ToggleId { get; }

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

        public void SelectItem(string key)
        {
            if (Variant == SelectVariant.Single || Variant == SelectVariant.Typeahead)
            {
                SelectedItems.Clear();
            }

            SelectedItems.Add(key);

            // TODO: review if this is required
            // RaisePropertyChanged(nameof(SelectedItems));
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
                // RaisePropertyChanged(nameof(SelectedItems));
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

        protected void ButtonClick()
        {
            ClearSelection(false);
        }

        protected void OnFilterInput(ChangeEventArgs e)
        {
            FilterText = (string)e.Value;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (SelectedItems is null)
            {
                SelectedItems = new ObservableCollection<string>();
            }

            if (DataSource is not null)
            {
                InitializeValues();
            }

            StateHasChanged();
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsExpanded))
            {
                IsExpandedChanged.InvokeAsync(IsExpanded);
            }
            else if ((Variant == SelectVariant.Typeahead || Variant == SelectVariant.TypeaheadMulti) && e.PropertyName == nameof(FilterText))
            {
                StateHasChanged();
            }
        }

        protected void Toggle()
        {
            IsExpanded = !IsExpanded;
        }

        protected void UnselectFirstItem()
        {
            var firstOrDefault = SelectedItems.FirstOrDefault();
            UnselectItem(firstOrDefault);
        }

        private void InitializeValues()
        {
            Values.Clear();
            foreach (var record in DataSource)
            {
                string key = null;
                string value = null;
                if (KeyFunc is not null)
                {
                    key = KeyFunc(record);
                }

                if (ValueFunc is not null)
                {
                    value = ValueFunc(record);
                }

                if (value is not null)
                {
                    Values[key ?? value] = value;
                }
            }
        }
    }
}
