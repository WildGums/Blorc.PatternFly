namespace Blorc.Components
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Blorc.Bindings;
    using Blorc.Data;
    using Blorc.Logging;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;

    public abstract partial class BlorcComponentBase : ComponentBase, IDisposable, INotifyPropertyChanged
    {
        private static readonly Dictionary<string, int> InstanceCounters = new Dictionary<string, int>();

        private readonly List<IStateConverterContainer> _stateConverterContainers = new List<IStateConverterContainer>();
        private readonly PropertyBag _propertyBag = new PropertyBag();

        private bool _suspendUpdates;
        private bool _disposedValue;

        public BlorcComponentBase()
        {
            BindingContext = new BindingContext();

            _propertyBag.PropertyChanged += OnPropertyBagPropertyChanged;
        }

        protected BindingContext BindingContext { get; private set; }

        protected StateConverterContainer CreateConverter()
        {
            var container = new StateConverterContainer(this);

            _stateConverterContainers.Add(container);

            return container;
        }

        protected override void OnInit()
        {
            base.OnInit();
        }

        protected virtual void CreateBindings()
        {

        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (_stateConverterContainers.Count > 0)
            {
                _suspendUpdates = true;

                CreateBindings();

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

        protected string GenerateUniqueId(string prefix)
        {
            if (InstanceCounters.TryGetValue(prefix, out var index))
            {
            }

            InstanceCounters[prefix] = ++index;

            return $"{prefix}-{index}";
        }

        protected virtual void DisposeManaged()
        {
            BindingContext.Dispose();
            BindingContext = null;

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
