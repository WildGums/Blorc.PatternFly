namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Blorc.Components;

    public class SelectDemoComponent : BlorcComponentBase
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            SelectedItems2 = new ObservableCollection<string> {"1"};
        }

        public ObservableCollection<string> SelectedItems
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems));
            set => SetPropertyValue(nameof(SelectedItems), value);
        }

        public ObservableCollection<string> SelectedItems2
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems2));
            set => SetPropertyValue(nameof(SelectedItems2), value);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(SelectedItems) && SelectedItems != null)
            {
                SelectedItems.CollectionChanged += (sender, args) =>
                {
                    Console.WriteLine($"SelectedItems: {SelectedItems.Count}");
                };
            }

            if (e.PropertyName == nameof(SelectedItems2) && SelectedItems2 != null)
            {
                Console.WriteLine($"Changed SelectedItems2: {SelectedItems2.Count}");
                SelectedItems2.CollectionChanged += (sender, args) =>
                {
                    Console.WriteLine($"SelectedItems2: {SelectedItems2.Count}");
                };
            }
        }

        private void OnSingleSelectInputSelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Selection changed");
        }

        protected bool CustomMatch(string filter, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(filter))
            {
                return true;
            }

            return value.ToLower().Contains(filter.ToLower());
        }
    }
}
