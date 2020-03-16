namespace Blorc.PatternFly.Example.Pages.Components
{
    using Blorc.Components;
    using Blorc.PatternFly.Services.Interfaces;

    public class AboutModalDemoComponent : BlorcComponentBase
    {
        public AboutModalDemoComponent()
            : base(true)
        {
        }

        protected ISourceContainerService AboutModalContainerService { get; set; }

        public void Close()
        {
            AboutModalContainerService.HideContentAsync();
        }

        protected void OnButtonClick()
        {
            AboutModalContainerService.ShowContentAsync();
        }
    }
}
