namespace Blorc.PatternFly.Components.AboutModal
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AboutModalComponent : BlorcComponentBase
    {
        protected bool IsOpen { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public string StrapLine { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string BrandImageSrc { get; set; }

        [Parameter]
        public string BrandImageAlt { get; set; }

        public void Show()
        {
            IsOpen = true;
            StateHasChanged();
        }

        public void Close()
        {
            IsOpen = false;
            StateHasChanged();
        }
    }
}
