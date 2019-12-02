namespace Blorc.PatternFly.Components.Table
{
    using System.ComponentModel;

    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class RowComponent : BlorcComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string Class { get; set; }

        [Parameter]
        public object Record { get; set; } 

        [CascadingParameter]
        public TableComponent ContainerTable { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (ContainerTable != null)
            {
                StateHasChanged();
            }

            if (Record is INotifyPropertyChanged propertyChanged)
            {
                propertyChanged.PropertyChanged += (sender, args) => StateHasChanged();
            }
        }
    }
}
