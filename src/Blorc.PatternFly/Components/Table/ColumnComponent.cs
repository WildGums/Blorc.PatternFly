namespace Blorc.PatternFly.Components.Table
{
    using Blorc.Components;
    using Blorc.PatternFly.Components.ToggleComponentContainer;

    using EventArgs;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class ColumnComponent : BlorcComponentBase
    {
        public ColumnComponent()
        {
            CreateConverter()
                .Fixed("")
                .If(() => Align == Align.Center, "pf-m-center")
                .If(() => IsSortable, "pf-c-table__sort")
                .If(() => IsSelected, "pf-m-selected")
                .Watch(() => Align)
                .Watch(() => IsSortable)
                .Watch(() => IsSelected)
                .Update(() => Class);

            CreateConverter()
                .Fixed("")
                .If(() => Order == Order.None, "M214.059 377.941H168V134.059h46.059c21.382 0 32.09-25.851 16.971-40.971L144.971 7.029c-9.373-9.373-24.568-9.373-33.941 0L24.971 93.088c-15.119 15.119-4.411 40.971 16.971 40.971H88v243.882H41.941c-21.382 0-32.09 25.851-16.971 40.971l86.059 86.059c9.373 9.373 24.568 9.373 33.941 0l86.059-86.059c15.12-15.119 4.412-40.971-16.97-40.971z")
                .If(() => Order == Order.Descending, "M168 345.941V44c0-6.627-5.373-12-12-12h-56c-6.627 0-12 5.373-12 12v301.941H41.941c-21.382 0-32.09 25.851-16.971 40.971l86.059 86.059c9.373 9.373 24.569 9.373 33.941 0l86.059-86.059c15.119-15.119 4.411-40.971-16.971-40.971H168z")
                .If(() => Order == Order.Ascending, "M88 166.059V468c0 6.627 5.373 12 12 12h56c6.627 0 12-5.373 12-12V166.059h46.059c21.382 0 32.09-25.851 16.971-40.971l-86.059-86.059c-9.373-9.373-24.569-9.373-33.941 0l-86.059 86.059c-15.119 15.119-4.411 40.971 16.971 40.971H88z")
                .Watch(() => Order)
                .Update(() => Path);
        }

        public string Path { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Key { get; set; }

        public string Class { get; set; }

        [Parameter]
        public bool IsSortable
        {
            get => GetPropertyValue<bool>(nameof(IsSortable));
            set => SetPropertyValue(nameof(IsSortable), value);
        }

        [Parameter]
        public bool IsSelected
        {
            get => GetPropertyValue<bool>(nameof(IsSelected));
            set => SetPropertyValue(nameof(IsSelected), value);
        }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }

        [Parameter]
        public Order Order
        {
            get => GetPropertyValue<Order>(nameof(Order));
            set => SetPropertyValue(nameof(Order), value);
        }

        [CascadingParameter]
        public TableComponent ContainerTable { get; set; }  
        
        [CascadingParameter]
        public IToggleComponentContainer ToggleComponentContainer { get; set; }

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

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (!string.IsNullOrWhiteSpace(Key))
            {
                ContainerTable.ColumnDefinitions[Key] = new ColumnDefinition
                {
                    Label = Label, 
                    Key = Key,
                    Idx = Idx
                };
            }

            ContainerTable.OrderByColumnChanged += ContainerTableOnOrderByColumnChanged;
        }

        [Parameter]
        public int Idx { get; set; }

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
