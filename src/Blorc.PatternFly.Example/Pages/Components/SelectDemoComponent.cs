namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using Blorc.Components;

    public class SelectDemoComponent : BlorcComponentBase
    {
        public ObservableCollection<string> SelectedItems
        {
            get => GetPropertyValue<ObservableCollection<string>>(nameof(SelectedItems));
            set => SetPropertyValue(nameof(SelectedItems), value);
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
