namespace Blorc.PatternFly.Layouts.Toolbar
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class ToolbarComponent : BlorcComponentBase
    {
        public ToolbarComponent()
        {
            CreateConverter()
                .Fixed("pf-l-toolbar")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
