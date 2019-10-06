namespace Blorc.PatternFly.Components.Modal
{
    using System.ComponentModel;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

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
        public ModalSize Size
        {
            get { return GetPropertyValue<ModalSize>(nameof(Size)); }
            set { SetPropertyValue(nameof(Size), value); }
        }

        [Parameter] 
        public bool ShowCloseButton { get; set; }


        [Parameter] 
        public bool IsVisble
        {
            get { return GetPropertyValue<bool>(nameof(IsVisble)); }
            set { SetPropertyValue(nameof(IsVisble), value); }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsVisble))
            {
                StateHasChanged();
            }
        }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        public string Class { get; set; }

        public void Close()
        {
            IsVisble = false;
        }

        public void Show()
        {
            IsVisble = true;
        }
    }
}
