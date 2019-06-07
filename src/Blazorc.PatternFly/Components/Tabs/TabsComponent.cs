namespace Blazorc.PatternFly.Components.Tabs
{
    using System;
    using Blazorc.Components;
    using Blazorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public class TabsComponent : BlazorcComponentBase
    {
        public TabsComponent()
        {
            Variant = TabsVariant.Div;
            LeftScrollAriaLabel = "Scroll left";
            RightScrollAriaLabel = "Scroll right";

            CreateConverter()
                .Fixed("pf-c-tabs")
                .If(() => IsSecondary, "pf-m-tabs-secondary")
                .If(() => IsFilled, "pf-m-fill")
                .Watch(() => IsSecondary)
                .Watch(() => IsFilled)
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public TabsVariant Variant
        {
            get { return GetPropertyValue<TabsVariant>(nameof(Variant)); }
            set { SetPropertyValue(nameof(Variant), value); }
        }

        [Parameter]
        public string Href
        {
            get { return GetPropertyValue<string>(nameof(Href)); }
            set { SetPropertyValue(nameof(Href), value); }
        }

        [Parameter]
        public string Title
        {
            get { return GetPropertyValue<string>(nameof(Title)); }
            set { SetPropertyValue(nameof(Title), value); }
        }

        [Parameter]
        public bool IsFilled
        {
            get { return GetPropertyValue<bool>(nameof(IsFilled)); }
            set { SetPropertyValue(nameof(IsFilled), value); }
        }

        [Parameter]
        public bool IsSecondary
        {
            get { return GetPropertyValue<bool>(nameof(IsSecondary)); }
            set { SetPropertyValue(nameof(IsSecondary), value); }
        }

        [Parameter]
        public string AriaLabel
        {
            get { return GetPropertyValue<string>(nameof(AriaLabel)); }
            set { SetPropertyValue(nameof(AriaLabel), value); }
        }

        [Parameter]
        public string LeftScrollAriaLabel
        {
            get { return GetPropertyValue<string>(nameof(LeftScrollAriaLabel)); }
            set { SetPropertyValue(nameof(LeftScrollAriaLabel), value); }
        }

        [Parameter]
        public string RightScrollAriaLabel
        {
            get { return GetPropertyValue<string>(nameof(RightScrollAriaLabel)); }
            set { SetPropertyValue(nameof(RightScrollAriaLabel), value); }
        }

        [Parameter]
        public int SelectedId
        {
            get { return GetPropertyValue<int>(nameof(SelectedId)); }
            set { SetPropertyValue(nameof(SelectedId), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> SelectedTabChanged { get; set; }

        public ITab ActiveTab { get; private set; }

        public void AddTab(ITab tab)
        {
            if (ActiveTab is null)
            {
                SetActivateTab(tab);
            }
        }

        public void RemoveTab(ITab tab)
        {
            if (ActiveTab == tab)
            {
                SetActivateTab(null);
            }
        }

        public void SetActivateTab(ITab tab)
        {
            if (ActiveTab != tab)
            {
                ActiveTab = tab;
                SelectedId = tab?.Id ?? -1;

                SelectedTabChanged?.Invoke(this, EventArgs.Empty);

                StateHasChanged();
            }
        }
    }
}
