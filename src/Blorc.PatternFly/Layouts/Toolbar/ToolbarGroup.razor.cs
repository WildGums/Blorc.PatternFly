namespace Blorc.PatternFly.Layouts.Toolbar
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class ToolbarGroupComponent : BlorcComponentBase
    {
        public ToolbarGroupComponent()
        {
            CreateConverter()
                .Fixed("pf-l-toolbar__group")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
