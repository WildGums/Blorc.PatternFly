namespace Blazorc.PatternFly.Components.Dropdown
{
    using Microsoft.AspNetCore.Components;

    public class DropdownGroupComponent : BlazorcComponentBase
    {
        public DropdownGroupComponent()
        {
        }

        [Parameter]
        public string Label
        {
            get { return GetPropertyValue<string>(nameof(Label)); }
            set { SetPropertyValue(nameof(Label), value); }
        }

        [Parameter]
        public string Key
        {
            get { return GetPropertyValue<string>(nameof(Key)); }
            set { SetPropertyValue(nameof(Key), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
