namespace Blorc.PatternFly.Components.Page
{
    using Blorc.Components;
    using Blorc.PatternFly.Services.Interfaces;

    using Microsoft.AspNetCore.Components;

    public class PageComponent : BlorcComponentBase
    {
        public PageComponent()
            : base(true)
        {
            IncludeTargetContainer = true;
        }

        [Parameter]
        public bool IncludeTargetContainer
        {
            get => GetPropertyValue<bool>(nameof(IncludeTargetContainer));
            set => SetPropertyValue(nameof(IncludeTargetContainer), value);
        }

        [Parameter]
        public RenderFragment LogoContent { get; set; }

        [Parameter]
        public RenderFragment MainContent { get; set; }

        public SidebarComponent Sidebar { get; set; }

        [Parameter]
        public RenderFragment SidebarContent { get; set; }

        public string Theme
        {
            get => GetPropertyValue<string>(nameof(Theme));
            set => SetPropertyValue(nameof(Theme), value);
        }

        [Parameter]
        public RenderFragment ToolbarContent { get; set; }

        protected ITargetContainerService TargetContainerService { get; set; }

        protected void OnClickNavbarToogle()
        {
            if (Sidebar != null)
            {
                Sidebar.IsExpanded = !Sidebar.IsExpanded;
            }
        }
    }
}
