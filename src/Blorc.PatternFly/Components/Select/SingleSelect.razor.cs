namespace Blorc.PatternFly.Components.Select

{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class SingleSelectComponent : BlorcComponentBase
    {
        [Parameter] public object SelectedItem { get; set; }

        [Parameter] public bool IsExpanded { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
