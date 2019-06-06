namespace Blazorc.PatternFly.Components
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Blazorc.PatternFly.Data;
    using Microsoft.AspNetCore.Components;

    public abstract partial class BlazorcComponentBase : ComponentBase, IDisposable, INotifyPropertyChanged
    {
        private readonly List<IStateConverterContainer> _stateConverterContainers = new List<IStateConverterContainer>();
        private readonly PropertyBag _propertyBag = new PropertyBag();

        private bool _suspendUpdates;
        private bool _disposedValue;

        public BlazorcComponentBase()
        {
            _propertyBag.PropertyChanged += OnPropertyBagPropertyChanged;
        }

        protected StateConverterContainer CreateConverter()
        {
            var container = new StateConverterContainer(this);

            _stateConverterContainers.Add(container);

            return container;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (_stateConverterContainers.Count > 0)
            {
                _suspendUpdates = true;

                _stateConverterContainers.ForEach(x => x.MarkDirty());

                _suspendUpdates = false;

                StateHasChanged();
            }
        }

        public void ForceUpdate()
        {
            if (_suspendUpdates)
            {
                return;
            }

            Log.Debug($"Forcing update for {GetType().Name}");

            StateHasChanged();
        }

        protected virtual void DisposeManaged()
        {
            _stateConverterContainers.ForEach(x => x.Dispose());
            _stateConverterContainers.Clear();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    DisposeManaged();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
