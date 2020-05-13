namespace Blorc.PatternFly.Components.Brand
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class BrandComponent : BlorcComponentBase
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
