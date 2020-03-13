namespace Blorc.PatternFly.Components.Pagination
{
    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public class PaginationComponent : BlorcComponentBase
    {
        public PaginationComponent()
        {
            CreateConverter().Fixed("pf-c-pagination")
                .If(() => IsCompact, "pf-m-compact").Watch(() => IsCompact)
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public bool IsCompact
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsCompact));
            }

            set
            {
                SetPropertyValue(nameof(IsCompact), value);
            }
        }

        [Parameter]
        public int ItemsCount
        {
            get
            {
                return GetPropertyValue<int>(nameof(ItemsCount));
            }

            set
            {
                SetPropertyValue(nameof(ItemsCount), value);
            }
        }

        [Parameter]
        public int ItemsPerPage
        {
            get
            {
                return GetPropertyValue<int>(nameof(ItemsPerPage));
            }

            set
            {
                SetPropertyValue(nameof(ItemsPerPage), value);
            }
        }

        [Parameter]
        public EventCallback<PaginationEventArgs> OnStateChanged { get; set; }

        public int PageFirstItemIndex
        {
            get { return PageIndex * ItemsPerPage; }
        }

        [Parameter]
        public int PageIndex
        {
            get
            {
                return GetPropertyValue<int>(nameof(PageIndex));
            }

            set
            {
                SetPropertyValue(nameof(PageIndex), value);
            }
        }

        public int PageLastItemIndex
        {
            get { return (PageIndex + 1) * ItemsPerPage - 1; }
        }

        public int PagesCount
        {
            get
            {
                return ItemsCount / ItemsPerPage;
            }
        }

        public PaginationVariant Variant
        {
            get
            {
                return GetPropertyValue<PaginationVariant>(nameof(Variant));
            }

            set
            {
                SetPropertyValue(nameof(Variant), value);
            }
        }

        protected void OnNextPageButtonPressed()
        {
            PageIndex++;
            StateHasChanged();
            InvokeAsync(() => OnStateChanged.InvokeAsync(new PaginationEventArgs(PageFirstItemIndex, ItemsPerPage)));
        }

        protected void OnPrevPageButtonPressed()
        {
            PageIndex--;
            StateHasChanged();
            InvokeAsync(() => OnStateChanged.InvokeAsync(new PaginationEventArgs(PageFirstItemIndex, ItemsPerPage)));
        }
    }
}
