namespace Blazorc.PatternFly.Example.Components.Example
{
    using Microsoft.AspNetCore.Components;

    public class ExampleComponent : ComponentBase
    {
        [Parameter]
        public string Title { get; set; }

        public string Slug
        {
            get
            {
                return Title?.Replace(" ", "-").Replace("(", string.Empty).Replace(")", string.Empty).ToLower();
            }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
