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
    using Blorc.PatternFly.Helpers;

    using Microsoft.AspNetCore.Components;

    public class TableComponent : BlorcComponentBase
    {
        private bool _sorting;

        public event EventHandler<OrderByColumnChangedEventArg> OrderByColumnChanged;

        [Parameter]
        public bool AlwaysReload { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public string Caption { get; set; }

        public SortedDictionary<string, ColumnDefinition> ColumnDefinitions { get; } = new SortedDictionary<string, ColumnDefinition>();

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
        public RenderFragment Header { get; set; }

        public bool IsSorted => OrderState != null && OrderState.IsSorted;

        [Parameter]
        public RenderFragment NoRowsContent { get; set; }

        public OrderState OrderState { get; set; }

        public bool IsSortedBy(string propertyName)
        {
            return OrderState != null && OrderState.IsSortedBy(propertyName);
        }

        public void OrderBy(ColumnComponent columnComponent, Order order)
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
