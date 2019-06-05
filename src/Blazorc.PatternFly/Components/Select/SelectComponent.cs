namespace Blazorc.PatternFly.Components.Select

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Icon;
    using Microsoft.AspNetCore.Components;

    public class SelectComponent : UniqueComponentBase
    {
        public SelectComponent()
        {
            Variant = SelectVariant.Single;

            AriaLabelClear = "Clear all";
            ArieLabelToggle = "Options menu";
            AriaLabelRemove = "Remove";

            ToggleId = GenerateUniqueId("pf-toggle-id");
        }

        public string Class
        {
            get
            {
                var items = new List<string>();

                if (IsExpanded)
                {
                    items.Add("pf-m-expanded");
                }

                return string.Join(" ", items);
            }
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

        public override string ComponentName => "Select";

        protected string ToggleId { get; }

        [Parameter]
        public SelectVariant Variant { get; set; }

        [Parameter]
        public bool IsExpanded { get; set; }

        [Parameter]
        public bool IsGrouped { get; set; }

        [Parameter]
        public string PlaceholderText { get; set; }

        [Parameter]
        public List<object> SelectedItems { get; set; }

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
        public RenderFragment ChildContent { get; set; }

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
                if (Variant == SelectVariant.Single)
                {
                    var tuple = (Tuple<string, string>)SelectedItems.FirstOrDefault();
                    return tuple?.Item2;
                }

                return string.Empty;
            }
        }

        protected void Toggle()
        {
            IsExpanded = !IsExpanded;
            StateHasChanged();
        }

        public void SelectItem(string key, string value)
        {
            Console.WriteLine("Selected Item => " + key);
            if (Variant == SelectVariant.Single)
            {
                SelectedItems.Clear();
            }

            SelectedItems.Add(new Tuple<string, string>(key, value));
            Console.WriteLine(SelectedItems.Count);
            Toggle();
        }

        public void UnselectItem(string key)
        {
            Console.WriteLine("Unselected Item => " + key);
            var firstOrDefault = SelectedItems.OfType<Tuple<string, string>>().FirstOrDefault(tuple => tuple.Item1 == key);
            if (firstOrDefault != null)
            {
                SelectedItems.Remove(firstOrDefault);
            }

            Toggle();
        }
    }
}
