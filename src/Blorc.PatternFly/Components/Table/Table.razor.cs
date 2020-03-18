namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Table.EventArgs;
    using Blorc.Reflection;

    using Microsoft.AspNetCore.Components;

    public class TableComponent : BlorcComponentBase
    {
        public event EventHandler<OrderByColumnChangedEventArg> OrderByColumnChanged;

        [Parameter]
        public bool AlwaysReload { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public string Caption { get; set; }

        [Parameter]
        public RenderFragment NoRowsContent { get; set; }

        public SortedDictionary<string, ColumnDefinition> ColumnDefinitions { get; } = new SortedDictionary<string, ColumnDefinition>();

        [Parameter]
        public Func<IEnumerable> DataSource { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        public bool IsSorted => OrderState != null && OrderState.IsSorted;

        public OrderState OrderState { get; set; }

        protected IEnumerable Records { get; set; }

        public bool IsSortedBy(string propertyName)
        {
            return OrderState != null && OrderState.IsSortedBy(propertyName);
        }

        public void OrderBy(ColumnComponent columnComponent, Order order)
        {
            OrderState = new OrderState(columnComponent.Key, order, columnComponent.Comparer);

            OrderByColumnChanged?.Invoke(this, new OrderByColumnChangedEventArg(columnComponent));

            if (Records == null || AlwaysReload)
            {
                Records = DataSource.Invoke();
            }

            SortIfRequired();
            StateHasChanged();
        }

        public void Refresh(bool reload = false)
        {
            if (reload)
            {
                Records = DataSource?.Invoke();
            }

            SortIfRequired();
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            if (Records == null)
            {
                Records = DataSource?.Invoke();
                StateHasChanged();
            }
        }

        private void SortIfRequired()
        {
            if (OrderState is null)
            {
                return;
            }

            if (OrderState.Order == Order.Ascending)
            {
                Records = Records.OfType<object>().OrderBy(o => PropertyHelper.GetPropertyValue(o, OrderState.Key), OrderState.Comparer);
            }
            else if (OrderState.Order == Order.Descending)
            {
                Records = Records.OfType<object>().OrderByDescending(o => PropertyHelper.GetPropertyValue(o, OrderState.Key), OrderState.Comparer);
            }
        }
    }
}
