namespace Blorc.PatternFly.Components.Page
{
    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public partial class Page : BlorcComponentBase
    {
        public Page ()
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

        public Sidebar Sidebar { get; set; }

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
            if (Sidebar is not null)
            {
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
                Sidebar.IsExpanded = !Sidebar.IsExpanded;
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
            }
        }
    }
}
