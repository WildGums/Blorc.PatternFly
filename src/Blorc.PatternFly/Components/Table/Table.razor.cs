namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Table.EventArgs;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class Table : UniqueComponentBase
    {
        private bool _sorting;

        public Table()
        {
            TableId = GenerateUniqueId("pf-table-id");
            CreateConverter()
                .Fixed("pf-c-table")
                .If(() => GridSize == GridSize.Md, "pf-m-grid-md")
                .If(() => GridSize == GridSize.Xl, "pf-m-grid-xl")
                .If(() => IsStickyHeader, "pf-m-sticky-header")
                .Watch(() => GridSize)
                .Watch(() => IsStickyHeader)
                .Update(() => Class);

            GridSize = GridSize.Md;
            IsStickyHeader = false;
        }

        public event EventHandler<OrderByColumnChangedEventArg> OrderByColumnChanged;

        [Parameter]
        public bool AlwaysReload { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public string Caption { get; set; }

        public string Class { get; set; }

        [Parameter]
        public SortedDictionary<string, ColumnDefinition> ColumnDefinitions { get; set; } = new SortedDictionary<string, ColumnDefinition>();

        public override string ComponentName { get { return "table"; } }

        [Parameter]
        public string CustomHighlightStyle
        {
            get;
            set;
        }

        [Parameter]
        public IEnumerable DataSource
        {
            get
            {
                return GetPropertyValue<IEnumerable>(nameof(DataSource));
            }

            set
            {
                SetPropertyValue(nameof(DataSource), value);
            }
        }

        [Parameter]
        public Func<IEnumerable> DataSourceFunc { get; set; }

        [Parameter]
        public GridSize GridSize
        {
            get { return GetPropertyValue<GridSize>(nameof(GridSize)); }
            set { SetPropertyValue(nameof(GridSize), value); }
        }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public Predicate<object> HighlightPredicate { get; set; }   
        
        [Parameter]
        public Func<object, string> HighlightStyleFunc { get; set; }

        [Parameter]
        public string Id { get; set; }

        public bool IsSorted => OrderState != null && OrderState.IsSorted;

        [Parameter]
        public bool IsStickyHeader
        {
            get { return GetPropertyValue<bool>(nameof(IsStickyHeader)); }
            set { SetPropertyValue(nameof(IsStickyHeader), value); }
        }

        [Parameter]
        public RenderFragment NoRowsContent { get; set; }

        public OrderState OrderState { get; set; }

        public string TableId { get; }

        public bool IsSortedBy(string propertyName)
        {
            return OrderState != null && OrderState.IsSortedBy(propertyName);
        }

        public void OrderBy(Column columnComponent, Order order)
        {
            OrderState = new OrderState(columnComponent.Key, order, columnComponent.Comparer);

            OrderByColumnChanged?.Invoke(this, new OrderByColumnChangedEventArg(columnComponent));

            if (DataSource == null || AlwaysReload)
            {
                DataSource = DataSourceFunc.Invoke();
            }

            SortIfRequired();
            StateHasChanged();
        }

        public void Refresh(bool reload = false)
        {
            if (reload)
            {
                DataSource = DataSourceFunc?.Invoke();
            }
            else
            {
                SortIfRequired();
                StateHasChanged();
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender && Header != null && ColumnDefinitions.Count > 0)
            {
                StateHasChanged();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (DataSource == null)
            {
                DataSource = DataSourceFunc?.Invoke();
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(DataSource))
            {
                if (!_sorting)
                {
                    SortIfRequired();
                }
                else
                {
                    StateHasChanged();
                }
            }
        }

        private void SortIfRequired()
        {
            if (DataSource != null)
            {
                if (OrderState is null)
                {
                    return;
                }

                _sorting = true;

                if (OrderState.Order == Order.Ascending)
                {
                    DataSource = DataSource.OfType<object>().OrderBy(o => DataHelper.GetValue(o, OrderState.Key), OrderState.Comparer);
                }
                else if (OrderState.Order == Order.Descending)
                {
                    DataSource = DataSource.OfType<object>().OrderByDescending(o => DataHelper.GetValue(o, OrderState.Key), OrderState.Comparer);
                }

                _sorting = false;
            }
        }
    }
}
