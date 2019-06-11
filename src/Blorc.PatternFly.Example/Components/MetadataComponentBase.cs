namespace Blorc.PatternFly.Example.Components
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public abstract class MetadataComponentBase : BlorcComponentBase
    {
        [Parameter]
        public string ComponentName { get; set; }

        public string ComponentNameSlug
        {
            get
            {
                return ComponentName?.Replace(" ", string.Empty).Replace("-", string.Empty);
            }
        }
    }
}
