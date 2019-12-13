namespace Blorc.PatternFly.Components.Page
{
    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public class SidebarComponent : BlorcComponentBase
    {
        public SidebarComponent()
        {
            CreateConverter()
                .Fixed("pf-c-page__sidebar")
                .If(() => IsExpanded, "pf-m-expanded")
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
        public PageComponent PageComponent { get; set; }

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
