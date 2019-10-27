namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using Blorc.Components;
    using EventArgs;
    using Microsoft.AspNetCore.Components;
    using Reflection;
    using Select;

    public class TableComponent : BlorcComponentBase
    {
        protected IEnumerable Records { get; set; }

        public TableComponent()
        {
        }

        [Parameter]
        public string Caption { get; set; }
        
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }       
        
        [Parameter]
        public RenderFragment Body { get; set; }

        public SortedDictionary<string, ColumnDefinition> ColumnDefinitions { get; } = new SortedDictionary<string, ColumnDefinition>();

        public event EventHandler<OrderByColumnChangedEventArg> OrderByColumnChanged;

        public void OrderBy(ColumnComponent columnComponent, Order order)
        {
            OrderByColumnChanged?.Invoke(this, new OrderByColumnChangedEventArg(columnComponent));
           
            if (Records == null || AlwaysReload)
            {
                Records = DataSource.Invoke();
            }

            if (order == Order.Ascending)
            {
                Records = Records.OfType<object>().OrderBy(o => PropertyHelper.GetPropertyValue(o, columnComponent.Key));
            }
            else if (order == Order.Descending)
            {
                Records = Records.OfType<object>().OrderByDescending(o => PropertyHelper.GetPropertyValue(o, columnComponent.Key));
            }

            StateHasChanged();
        }

        [Parameter]
        public bool AlwaysReload { get; set; }

        [Parameter]
        public Func<IEnumerable> DataSource { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Records == null)
            {
                Records = DataSource?.Invoke();
                StateHasChanged();
            }
        }
    }
}
