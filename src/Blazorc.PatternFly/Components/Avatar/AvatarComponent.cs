namespace Blazorc.PatternFly.Components.Avatar
{
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AvatarComponent : BlazorcComponentBase
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
