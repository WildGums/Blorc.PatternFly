namespace Blorc.PatternFly.Components.Select

{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class CheckboxSelectGroupComponent : BlorcComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
