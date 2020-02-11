namespace Blorc.PatternFly.Example.Components.Todo
{
    using Microsoft.AspNetCore.Components;

    public class TodoComponent : MetadataComponentBase
    {
        [Parameter]
        public RenderFragment TodoList { get; set; }
    }
}
