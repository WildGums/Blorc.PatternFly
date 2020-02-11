namespace Blorc.PatternFly.Layouts.Toolbar
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class ToolbarSectionComponent : BlorcComponentBase
    {
        public ToolbarSectionComponent()
        {
            CreateConverter()
                .Fixed("pf-l-toolbar__section")
                .Update(() => Class);
        }
        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string AriaLabel { get; set; }
    }
}
