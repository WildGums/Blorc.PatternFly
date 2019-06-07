namespace Blazorc.PatternFly.Components.Brand
{
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class BrandComponent : BlazorcComponentBase
    {
        public BrandComponent()
        {
            
        }

        [Parameter]
        public string Source { get; set; }

        [Parameter]
        public string Alt { get; set; }
    }
}
