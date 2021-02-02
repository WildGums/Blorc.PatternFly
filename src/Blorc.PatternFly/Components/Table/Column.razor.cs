namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Table.EventArgs;
    using Blorc.PatternFly.Components.ToggleComponentContainer;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class Column : BlorcComponentBase
    {
        public Column()
        {
            CreateConverter()
                .Fixed(string.Empty)
                .If(() => Align == Align.Center, "pf-m-center")
                .If(() => IsSortable, "pf-c-table__sort")
                .If(() => IsSelected, "pf-m-selected")
                .Watch(() => Align)
                .Watch(() => IsSortable)
                .Watch(() => IsSelected)
                .Update(() => Class);

            CreateConverter()
                .Fixed(string.Empty)
                .If(() => Order == Order.None, "M214.059 377.941H168V134.059h46.059c21.382 0 32.09-25.851 16.971-40.971L144.971 7.029c-9.373-9.373-24.568-9.373-33.941 0L24.971 93.088c-15.119 15.119-4.411 40.971 16.971 40.971H88v243.882H41.941c-21.382 0-32.09 25.851-16.971 40.971l86.059 86.059c9.373 9.373 24.568 9.373 33.941 0l86.059-86.059c15.12-15.119 4.412-40.971-16.97-40.971z")
                .If(() => Order == Order.Descending, "M168 345.941V44c0-6.627-5.373-12-12-12h-56c-6.627 0-12 5.373-12 12v301.941H41.941c-21.382 0-32.09 25.851-16.971 40.971l86.059 86.059c9.373 9.373 24.569 9.373 33.941 0l86.059-86.059c15.119-15.119 4.411-40.971-16.971-40.971H168z")
                .If(() => Order == Order.Ascending, "M88 166.059V468c0 6.627 5.373 12 12 12h56c6.627 0 12-5.373 12-12V166.059h46.059c21.382 0 32.09-25.851 16.971-40.971l-86.059-86.059c-9.373-9.373-24.569-9.373-33.941 0l-86.059 86.059c-15.119 15.119-4.411 40.971 16.971 40.971H88z")
                .Watch(() => Order)
                .Update(() => Path);
        }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }

        public string Class { get; set; }

        [Parameter]
        public IComparer Comparer
        {
            get => GetPropertyValue<IComparer>(nameof(Comparer));
            set => SetPropertyValue(nameof(Comparer), value);
        }

        [CascadingParameter]
        public Table ContainerTable { get; set; }

        [Parameter]
        public Predicate<object> FilterPredicate
        {
            get => GetPropertyValue<Predicate<object>>(nameof(FilterPredicate));
            set => SetPropertyValue(nameof(FilterPredicate), value);
        }

        [Parameter]
        public int Idx { get; set; }

        [Parameter]
        public bool IsSelected
        {
            get => GetPropertyValue<bool>(nameof(IsSelected));
            set => SetPropertyValue(nameof(IsSelected), value);
        }

        [Parameter]
        public bool IsSortable
        {
            get => GetPropertyValue<bool>(nameof(IsSortable));
            set => SetPropertyValue(nameof(IsSortable), value);
        }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public Order Order
        {
            get => GetPropertyValue<Order>(nameof(Order));
            set => SetPropertyValue(nameof(Order), value);
        }

        public string Path { get; set; }

        [CascadingParameter]
        public IToggleComponentContainer ToggleComponentContainer { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (!string.IsNullOrWhiteSpace(Key))
            {
                if (ContainerTable.ColumnDefinitions.TryGetValue(Key, out var columnDefinition))
                {
                    columnDefinition.IsSelected = IsSelected;
                }
                else
                {
                    ContainerTable.ColumnDefinitions[Key] = new ColumnDefinition
                    {
                        Label = Label,
                        Key = Key,
                        Idx = Idx,
                        IsSortable = IsSortable,
                        IsSelected = IsSelected,
                        FilterPredicate = FilterPredicate
                    };
                }
            }

            ContainerTable.OrderByColumnChanged += ContainerTableOnOrderByColumnChanged;
        }

        protected void Toggle()
        {
            switch (Order)
            {
                case Order.None:
                case Order.Ascending:
                    Order = Order.Descending;
                    break;
                case Order.Descending:
                    Order = Order.Ascending;
                    break;
            }

            ContainerTable.OrderBy(this, Order);
        }

        private void ContainerTableOnOrderByColumnChanged(object sender, OrderByColumnChangedEventArg e)
        {
            // ToggleComponentContainer.SetActiveToggleComponent(null);
            IsSelected = e.ColumnComponent == this;
            if (!IsSelected)
            {
                Order = Order.None;
            }
        }
    }
}
