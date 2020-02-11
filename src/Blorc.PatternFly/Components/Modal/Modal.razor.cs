namespace Blorc.PatternFly.Components.Modal
{
    using System.ComponentModel;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.Services;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public class ModalComponent : BlorcComponentBase
    {
        public ModalComponent()
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
        public RenderFragment Footer { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public bool IsVisble
        {
            get { return GetPropertyValue<bool>(nameof(IsVisble)); }
            set { SetPropertyValue(nameof(IsVisble), value); }
        }

        [Parameter]
        public bool ShowCloseButton { get; set; }

        [Parameter]
        public ModalSize Size
        {
            get { return GetPropertyValue<ModalSize>(nameof(Size)); }
            set { SetPropertyValue(nameof(Size), value); }
        }

        public void Close()
        {
            IsVisble = false;
        }

        public async Task CloseAsync()
        {
            await InvokeAsync(() => Close());
        }

        public void Show()
        {
            IsVisble = true;
        }

        public async Task ShowAsync()
        {
            await InvokeAsync(() => Show());
        }

        public async Task UpdateAsync()
        {
            await InvokeAsync(() => StateHasChanged());
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsVisble))
            {
                StateHasChanged();
            }
        }
    }
}
