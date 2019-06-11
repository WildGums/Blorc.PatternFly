namespace Blorc.PatternFly.Components.Avatar
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AvatarComponent : BlorcComponentBase
    {
        public AvatarComponent()
        {
            
        }

        [Parameter]
        public string Source { get; set; }

        [Parameter]
        public string Alt { get; set; }
    }
}
