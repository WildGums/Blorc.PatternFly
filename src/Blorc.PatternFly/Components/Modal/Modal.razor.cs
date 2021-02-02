namespace Blorc.PatternFly.Components.Modal
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Container;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class Modal : BlorcComponentBase
    {
        public Modal()
        {
            CreateConverter()
                .Fixed("pf-c-modal-box")
                .If(() => Size == ModalSize.Default, string.Empty)
                .If(() => Size == ModalSize.Large, "pf-m-lg")
                .If(() => Size == ModalSize.Small, "pf-m-sm")
                .Watch(() => Size)
                .Update(() => Class);
        }

        [Parameter]
        public RenderFragment Body { get; set; }

        public string Class { get; set; }

        [Parameter]
        public EventHandler CloseButtonPressed { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public bool IsOpen
        {
            get { return GetPropertyValue<bool>(nameof(IsOpen)); }
            set { SetPropertyValue(nameof(IsOpen), value); }
        }

        [Parameter]
        public bool ShowCloseButton { get; set; }

        [Parameter]
        public ModalSize Size
        {
            get { return GetPropertyValue<ModalSize>(nameof(Size)); }
            set { SetPropertyValue(nameof(Size), value); }
        }

        [CascadingParameter]
        public TargetContainer TargetContainer { get; set; }

        public void Close()
        {
            if (TargetContainer == null)
            {
                IsOpen = false;
            }

            RaiseCloseButtonPressed();
        }

        public async Task CloseAsync()
        {
            await InvokeAsync(() => Close());
        }

        public void Show()
        {
            if (TargetContainer == null)
            {
                IsOpen = true;
            }
        }

        public async Task ShowAsync()
        {
            await InvokeAsync(() => Show());
        }

        public async Task UpdateAsync()
        {
            await InvokeAsync(() => StateHasChanged());
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (TargetContainer != null)
            {
                IsOpen = true;
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsOpen))
            {
                StateHasChanged();
            }
        }

        protected virtual void RaiseCloseButtonPressed()
        {
            CloseButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
