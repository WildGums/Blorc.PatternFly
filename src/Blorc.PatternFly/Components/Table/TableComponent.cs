namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Blorc.Components;
    using Core;

    using EventArgs;
    using Microsoft.AspNetCore.Components;
    using Reflection;

    public class TableComponent : BlorcComponentBase, IToggleComponentContainer
    {
        protected IEnumerable Records { get; set; }

        [Parameter]
        public string Caption { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        public SortedDictionary<string, ColumnDefinition> ColumnDefinitions { get; } = new SortedDictionary<string, ColumnDefinition>();

        [Parameter]
        public bool AlwaysReload { get; set; }

        [Parameter]
        public Func<IEnumerable> DataSource { get; set; }

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

        protected override async Task OnInitializedAsync()
        {
            if (Records == null)
            {
                Records = DataSource?.Invoke();
                StateHasChanged();
            }
        }

        public void Refresh()
        {
            Records = DataSource?.Invoke();
            StateHasChanged();
        }

        public List<IToggleComponent> Components { get; } = new List<IToggleComponent>();
        
        public void SetActiveToggleComponent(IToggleComponent toggleComponent)
        {
            foreach (var component in Components)
            {
                if (component != toggleComponent)
                {
                    component.Close();
                }
            }
        }
    }
}
