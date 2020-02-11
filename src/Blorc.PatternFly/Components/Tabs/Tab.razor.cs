namespace Blorc.PatternFly.Components.Tabs
{
    using System;
    using System.ComponentModel;
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public class TabComponent : BlorcComponentBase, ITab
    {
        private static int Counter; 

        public TabComponent()
        {
            Id = ++Counter;
            UniqueLabelId =  GenerateUniqueId($"pf-tab-pf");
            UniqueSectionId = GenerateUniqueId($"pf-tab-section-pf");

            CreateConverter()
                .Fixed("pf-c-tabs__item")
                .If(() => IsSelected, "pf-m-current")
                .Watch(() => IsSelected)
                .Update(() => Class);
        }

        public string Class { get; set; }

        public string UniqueLabelId { get; set; }

        public string UniqueSectionId { get; set; }

        public bool IsSelected
        {
            get
            {
                var parent = TabsContainer;
                if (parent is null)
                {
                    return false;
                }

                return Id == parent.SelectedId;
            }
        }

        [CascadingParameter]
        public Tabs TabsContainer { get; set; }

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void OnInitialized()
        {
            TabsContainer.AddTab(this);
            TabsContainer.PropertyChanged += OnTabsContainerPropertyChanged;
        }

        protected override void DisposeManaged()
        {
            base.DisposeManaged();

            TabsContainer.PropertyChanged -= OnTabsContainerPropertyChanged;
            TabsContainer.RemoveTab(this);
        }

        protected void Activate()
        {
            TabsContainer.SetActivateTab(this);
        }

        private void OnTabsContainerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Tabs.SelectedId))
            {
                StateHasChanged();
            }
        }
    }
}
