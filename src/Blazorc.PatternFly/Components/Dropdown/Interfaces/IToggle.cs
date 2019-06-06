namespace Blazorc.PatternFly.Components.Dropdown
{
    using Microsoft.AspNetCore.Components;

    public interface IToggle
    {
        bool IsDisabled { get; set; }

        RenderFragment ChildContent { get; set; }
    }
}
