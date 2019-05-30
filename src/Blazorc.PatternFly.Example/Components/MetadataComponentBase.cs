namespace Blazorc.PatternFly.Example.Components
{
    using Microsoft.AspNetCore.Components;

    public abstract class MetadataComponentBase : ComponentBase
    {
        [Parameter]
        public string ComponentName { get; set; }

        public string ComponentNameSlug
        {
            get
            {
                return ComponentName?.Replace(" ", string.Empty).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
