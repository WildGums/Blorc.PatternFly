namespace Blorc.PatternFly.Layouts
{
    using System.Threading.Tasks;
    using Blorc.Components;
    using Blorc.Dom.Injectors;

    public class PatternFlyLayoutComponentBase : BlorcLayoutComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            DocumentService.InjectHead(new Css("_content/Blorc.PatternFly/patternfly/patternfly.css"));
        }
    }
}
