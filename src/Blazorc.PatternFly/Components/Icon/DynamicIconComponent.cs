namespace Blazorc.PatternFly.Components.Icon
{
    using Microsoft.AspNetCore.Components;

    public class DynamicIconComponent : ComponentBase
    {
        public DynamicIconComponent()
        {

        }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Class { get; set; }
    }
}
