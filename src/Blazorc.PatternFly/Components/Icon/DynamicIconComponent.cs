namespace Blazorc.PatternFly.Components.Icon
{
    using Microsoft.AspNetCore.Components;

    public class DynamicIconComponent : BlazorcComponentBase
    {
        public DynamicIconComponent()
        {

        }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string Class { get; set; }
    }
}
