namespace Blorc.PatternFly.Components.Brand
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class Brand : BlorcComponentBase
    {
        public Brand()
        {

        }

        [Parameter]
        public string Source { get; set; }

        [Parameter]
        public string Alt { get; set; }
    }
}
