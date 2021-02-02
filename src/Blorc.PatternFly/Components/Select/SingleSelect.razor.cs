namespace Blorc.PatternFly.Components.Select

{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class SingleSelect : BlorcComponentBase
    {
        [Parameter] public object SelectedItem { get; set; }

        [Parameter] public bool IsExpanded { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
