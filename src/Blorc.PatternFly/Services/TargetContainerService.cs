namespace Blorc.PatternFly
{
    using Blorc.PatternFly.Components.Container;
    using Blorc.PatternFly.Components.List;

    using Microsoft.AspNetCore.Components;

    public class TargetContainerService : ITargetContainerService
    {
        public ComponentBase Component { get; set; }

        public void Add(RenderFragment renderFragment)
        {
            ((TargetContainer)Component).RenderFragments.Add(renderFragment);
        }

        public void Remove(RenderFragment renderFragment)
        {
            ((TargetContainer)Component).RenderFragments.Remove(renderFragment);
        }
    }
}
