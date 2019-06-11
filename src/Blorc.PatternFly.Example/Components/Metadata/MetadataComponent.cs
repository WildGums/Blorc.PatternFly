namespace Blorc.PatternFly.Example.Components.Metadata
{
    using Microsoft.AspNetCore.Components;

    public class MetadataComponent : MetadataComponentBase
    {
        public MetadataComponent()
        {

        }

        [Parameter]
        public string DocumentationUrl { get; set; }

        [Parameter]
        public string SourceUrl { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            DocumentationUrl = $"https://www.patternfly.org/v4/documentation/react/components/{ComponentNameSlug.ToLower()}";
            SourceUrl = $"https://github.com/patternfly/patternfly-react/tree/master/packages/patternfly-4/react-core/src/components/{ComponentNameSlug}";
        }
    }
}
