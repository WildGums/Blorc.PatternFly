namespace Blorc.PatternFly.Components.Page
{
    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;
    using System.ComponentModel;

    public partial class Sidebar : BlorcComponentBase
    {
        public Sidebar()
        {
            CreateConverter()
                .Fixed("pf-c-page__sidebar ws-page-sidebar")
                .If(() => IsExpanded, "pf-m-expanded")
                .If(() => !IsExpanded, "pf-m-collapsed")
                .Update(() => Class);
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string Class
        {
            get => GetPropertyValue<string>(nameof(Class));
            set => SetPropertyValue(nameof(Class), value);
        }

        [Parameter]
        public bool IsExpanded
        {
            get => GetPropertyValue<bool>(nameof(IsExpanded));
            set => SetPropertyValue(nameof(IsExpanded), value);
        }

        [CascadingParameter]
        public Page PageComponent { get; set; }

        [Parameter]
        public string Theme
        {
            get => GetPropertyValue<string>(nameof(Theme));
            set => SetPropertyValue(nameof(Theme), value);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (PageComponent != null)
            {
                Theme = PageComponent.Theme;
            }

            IsExpanded = true;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (PageComponent != null)
            {
                StateHasChanged();
            }
        }
    }
}
