// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModalUIVisualizationService.cs" company="WildGums">
//   Copyright (c) 2008 - 2020 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blorc.PatternFly.Services
{
    using System;
    using System.Threading.Tasks;

    using Blorc.PatternFly.Components.Modal;
    using Blorc.Services;

    public class ModalUIVisualizationService : IUIVisualizationService
    {
        private readonly ModalComponent _modalComponent;

        public ModalUIVisualizationService(ModalComponent modalComponent)
        {
            _modalComponent = modalComponent ?? throw new ArgumentNullException(nameof(modalComponent));
        }

        public async Task CloseAsync()
        {
            await _modalComponent.CloseAsync();
        }

        public async Task ShowAsync()
        {
            await _modalComponent.ShowAsync();
        }

        public async Task UpdateAsync()
        {
        }
    }
}
