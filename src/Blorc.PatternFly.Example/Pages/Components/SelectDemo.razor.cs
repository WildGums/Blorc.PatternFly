namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using Blorc.Components;

    public class SelectDemoComponent : BlorcComponentBase
    {
        public List<Tuple<string, string>> DataSource { get; set; }

        public List<Tuple<string, string, string>> DataSource2 { get; set; }

        public bool IsSelectedExpanded
        {
            get => GetPropertyValue<bool>(nameof(IsSelectedExpanded));
            set => SetPropertyValue(nameof(IsSelectedExpanded), value);
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

        public ObservableCollection<string> SelectedItems5
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems5));
            set => SetPropertyValue(nameof(SelectedItems5), value);
        }

        public ObservableCollection<string> SelectedItems6
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems6));
            set => SetPropertyValue(nameof(SelectedItems6), value);
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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SelectedItems2 = new ObservableCollection<string> { "1" };
            SelectedItems4 = new ObservableCollection<string> { "1" };
            SelectedItems5 = new ObservableCollection<string> { "1", "7" };
            SelectedItems6 = new ObservableCollection<string> { "3" };
            DataSource = new List<Tuple<string, string>>
                         {
                             new Tuple<string, string>("0", "Active"),
                             new Tuple<string, string>("1", "Cancelled"),
                             new Tuple<string, string>("2", "Paused"),
                             new Tuple<string, string>("3", "Warning"),
                             new Tuple<string, string>("4", "Restarted")
                         };

            DataSource2 = new List<Tuple<string, string, string>>
                          {
                              new Tuple<string, string, string>("Status", "0", "Active"),
                              new Tuple<string, string, string>("Status", "1", "Cancelled"),
                              new Tuple<string, string, string>("Status", "2", "Paused"),
                              new Tuple<string, string, string>("Status", "3", "Warning"),
                              new Tuple<string, string, string>("Status", "4", "Restarted"),
                              new Tuple<string, string, string>("Vendor Names", "5", "Dell"),
                              new Tuple<string, string, string>("Vendor Names", "6", "Samsung"),
                              new Tuple<string, string, string>("Vendor Names", "7", "Hewlett-Packard")
                          };
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(IsSelectedExpanded))
            {
                Console.WriteLine("IsSelectExpanded Changed");
            }
            else if (e.PropertyName == nameof(SelectedItems) && SelectedItems != null)
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
            }
            else if (e.PropertyName == nameof(SelectedItems3) && SelectedItems3 != null)
            {
                Console.WriteLine($"Changed SelectedItems3: {SelectedItems3.Count}");
                SelectedItems3.CollectionChanged += (sender, args) =>
                {
                    Console.WriteLine($"SelectedItems3: {SelectedItems3.Count}");
                };
            }
            else if (e.PropertyName == nameof(SelectedItems4) && SelectedItems4 != null)
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
    }
}
