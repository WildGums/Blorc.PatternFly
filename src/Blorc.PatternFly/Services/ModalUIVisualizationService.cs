namespace Blorc.PatternFly
{
    using System.Threading.Tasks;

    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    using Microsoft.AspNetCore.Components;

    public class ModalUIVisualizationService : IUIVisualizationService
    {
        public ComponentBase Component { get; set; }

        public async Task CloseAsync()
        {
            await ((UIModal)Component).CloseAsync();
        }

        public async Task ShowAsync()
        {
            await ((UIModal)Component).ShowAsync();
        }

        public async Task UpdateAsync()
        {
            await ((UIModal)Component).UpdateAsync();
        }
    }
}
