namespace Blazorc.PatternFly.Components.Select

{
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class CheckboxSelectGroupComponent : BlazorcComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
