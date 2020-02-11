namespace Blorc.PatternFly.Layouts.Toolbar
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class ToolbarItemComponent : BlorcComponentBase
    {
        public ToolbarItemComponent()
        {
            CreateConverter()
                .Fixed("pf-l-toolbar__item")
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
