namespace Blorc.PatternFly.Components.Modal
{
    using System;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Services.Interfaces;

    using Microsoft.AspNetCore.Components;

    public class UIModalComponent : BlorcComponentBase
    {
        public UIModalComponent()
            : base(true)
        {
        }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public EventHandler CloseButtonPressed { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public bool ShowCloseButton { get; set; }

        [Parameter]
        public ModalSize Size { get; set; } = ModalSize.Small;

        protected ISourceContainerService ModalSourceContainerService { get; set; }

        public async Task CloseAsync()
        {
            await ModalSourceContainerService.HideContentAsync();
        }

        public async Task ShowAsync()
        {
            await ModalSourceContainerService.ShowContentAsync();
        }

        public async Task UpdateAsync()
        {
            await ModalSourceContainerService.UpdateContentAsync();
        }
    }
}
