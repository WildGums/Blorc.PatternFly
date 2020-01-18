namespace Blorc.PatternFly.Layouts
{
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.Services;

    public class PatternFlyLayoutComponentBase : BlorcLayoutComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await DocumentService.InjectAssemblyCSSFile(typeof(PatternFlyLayoutComponentBase).Assembly, "patternfly/patternfly.css");
        }
    }
}
