namespace Blorc.PatternFly.Components.AboutModal
{
    using System;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Container;

    using Microsoft.AspNetCore.Components;

    public partial class AboutModal : BlorcComponentBase
    {
        [Parameter]
        public string BrandImageAlt { get; set; }

        [Parameter]
        public string BrandImageSrc { get; set; }

        [Parameter]
        public EventHandler CloseButtonPressed { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [CascadingParameter]
        public TargetContainer TargetContainer { get; set; }

        [Parameter]
        public bool IsOpen
        {
            get { return GetPropertyValue<bool>(nameof(IsOpen)); }
            set { SetPropertyValue(nameof(IsOpen), value); }
        }

        [Parameter]
        public string StrapLine { get; set; }

        [Parameter]
        public string Title { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (TargetContainer is not null)
            {
                IsOpen = true;
            }
        }

        public void Close()
        {
            if (TargetContainer is null)
            {
                IsOpen = false;
                StateHasChanged();
            }

            RaiseCloseButtonPressed();
        }

        public void Show()
        {
            if (TargetContainer is null)
            {
                IsOpen = true;
                StateHasChanged();
            }
        }

        protected virtual void RaiseCloseButtonPressed()
        {
            CloseButtonPressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
