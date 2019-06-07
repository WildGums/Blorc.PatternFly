namespace Blazorc.PatternFly.Components.AboutModal
{
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AboutModalComponent : BlazorcComponentBase
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
