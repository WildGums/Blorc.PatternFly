namespace Blorc.PatternFly.Example.Pages.Components
{
    using Blorc.Components;

    public partial class AboutModalDemo : BlorcComponentBase
    {
        public AboutModalDemo()
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
