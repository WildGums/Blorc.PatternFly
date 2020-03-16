// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModalUIVisualizationService.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Services
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
            await ((UIModalComponent)Component).CloseAsync();
        }

        public async Task ShowAsync()
        {
            await ((UIModalComponent)Component).ShowAsync();
        }

        public async Task UpdateAsync()
        {
        }
    }
}
