namespace Blorc.PatternFly.Components.Table
{
    using System.ComponentModel;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Button;

    using Microsoft.AspNetCore.Components;

    public class RowComponent : BlorcComponentBase
    {
        protected static readonly ButtonVariant[] ButtonVariants = { ButtonVariant.Primary, ButtonVariant.Secondary, ButtonVariant.Tertiary };

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string Class { get; set; }

        [CascadingParameter]
        public TableComponent ContainerTable { get; set; }

        [Parameter]
        public object Record { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (ContainerTable != null)
            {
                StateHasChanged();
            }

            if (Record is INotifyPropertyChanged propertyChanged)
            {
                propertyChanged.PropertyChanged += OnPropertyChangedOnPropertyChanged;
            }
        }

        private void OnPropertyChangedOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (ContainerTable.IsSortedBy(args.PropertyName))
            {
                if (Record is INotifyPropertyChanged propertyChanged)
                {
                    propertyChanged.PropertyChanged -= OnPropertyChangedOnPropertyChanged;
                }

                ContainerTable.Refresh();
            }
            else
            {
                StateHasChanged();
            }
        }
    }
}
