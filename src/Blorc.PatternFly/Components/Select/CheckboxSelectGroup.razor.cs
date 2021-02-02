namespace Blorc.PatternFly.Components.Select

{
    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public partial class CheckboxSelectGroup : BlorcComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public Select ContainerSelect { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Label { get; set; }
    }
}
