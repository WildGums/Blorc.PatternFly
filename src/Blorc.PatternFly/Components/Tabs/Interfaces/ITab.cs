namespace Blorc.PatternFly.Components.Tabs
{
    using Microsoft.AspNetCore.Components;

    public interface ITab
    {
        int Id { get; }

        string UniqueLabelId { get; }

        string UniqueSectionId { get; set; }

        RenderFragment ChildContent { get; }
    }
}
