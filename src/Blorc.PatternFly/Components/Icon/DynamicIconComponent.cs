namespace Blorc.PatternFly.Components.Icon
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class DynamicIconComponent : BlorcComponentBase
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
