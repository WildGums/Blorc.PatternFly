namespace Blazorc.PatternFly.Components.Navigation
{
    using System;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using System.Transactions;
    using Catel.IoC;
    using Microsoft.AspNetCore.Components;

    public class NavigationItemComponent : ComponentBase
    {
        protected const string NavigationItemCurrentClass = "pf-c-nav__link pf-m-current";

        protected const string NavigationItemNormalClass = "pf-c-nav__link";
        [Microsoft.AspNetCore.Components.Inject]
        public IUriHelper UriHelper { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Link { get; set; }

        [Parameter]
        public NavigationExpandableSection Parent { get; set; }

        protected override async Task OnInitAsync()
        {
            Parent.InvalidatedCurrent += ParentOnInvalidatedCurrent;
        }

        private void ParentOnInvalidatedCurrent(object sender, EventArgs e)
        {
            IsCurrent = false;
        }

        protected void OnItemClick()
        {
            Parent.InvalidateCurrent();
            IsCurrent = true;
            Parent.Refresh(IsCurrent);
            // UriHelper.NavigateTo(Link);
        }

        public bool IsCurrent { get; private set; }
    }
}
