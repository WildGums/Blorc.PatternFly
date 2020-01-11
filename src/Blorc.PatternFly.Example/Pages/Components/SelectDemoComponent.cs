namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Blorc.Components;

    public class SelectDemoComponent : BlorcComponentBase
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            SelectedItems2 = new ObservableCollection<string> {"1"};
            SelectedItems4 = new ObservableCollection<string> { "1" };
            DataSource = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("0", "Active"),
                new Tuple<string, string>("1", "Cancelled"),
                new Tuple<string, string>("2", "Paused"),
                new Tuple<string, string>("3", "Warning"),
                new Tuple<string, string>("4", "Restarted"),
            };
        }

        public List<Tuple<string, string>> DataSource { get; set; }

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

        public ObservableCollection<string> SelectedItems3
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems3));
            set => SetPropertyValue(nameof(SelectedItems3), value);
        }

        public ObservableCollection<string> SelectedItems4
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems4));
            set => SetPropertyValue(nameof(SelectedItems4), value);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(SelectedItems) && SelectedItems != null)
            {
                Console.WriteLine($"Changed SelectedItems: {SelectedItems2.Count}");
                SelectedItems.CollectionChanged += (sender, args) =>
                {
                    Console.WriteLine($"SelectedItems: {SelectedItems.Count}");
                };
            }
            else if (e.PropertyName == nameof(SelectedItems2) && SelectedItems2 != null)
            {
                Console.WriteLine($"Changed SelectedItems2: {SelectedItems2.Count}");
                SelectedItems2.CollectionChanged += (sender, args) =>
                {
                    Console.WriteLine($"SelectedItems2: {SelectedItems2.Count}");
                };
            } else if (e.PropertyName == nameof(SelectedItems3) && SelectedItems3 != null)
            {
                Console.WriteLine($"Changed SelectedItems3: {SelectedItems3.Count}");
                SelectedItems3.CollectionChanged += (sender, args) =>
                {
                    Console.WriteLine($"SelectedItems3: {SelectedItems3.Count}");
                };
            } else if (e.PropertyName == nameof(SelectedItems4) && SelectedItems4 != null)
            {
                Console.WriteLine($"Changed SelectedItems4: {SelectedItems4.Count}");
                SelectedItems4.CollectionChanged += (sender, args) =>
                {
                    Console.WriteLine($"SelectedItems4: {SelectedItems4.Count}");
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
