namespace Blorc.PatternFly.Components.Avatar
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class Avatar : BlorcComponentBase
    {
        public Avatar()
        {
        }

        [Parameter]
        public string Source { get; set; }

        [Parameter]
        public string Alt { get; set; }
    }
}
