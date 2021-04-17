namespace Blorc.PatternFly.Components.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Button;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class ActionCell : BlorcComponentBase
    {
        protected static readonly ButtonVariant[] ButtonVariants = { ButtonVariant.Primary, ButtonVariant.Secondary, ButtonVariant.Tertiary };

        public ActionCell()
        {
            CreateConverter()
                .Fixed(string.Empty)
                .If(() => Align == Align.Center, "pf-m-center")
                .Watch(() => Align)
                .Update(() => Class);
        }

        [Parameter]
        public Func<object, IEnumerable<ActionDefinition>> ActionSource { get; set; }

        [Parameter]
        public ActionColumnType ActionType
        {
            get => GetPropertyValue<ActionColumnType>(nameof(ActionType));
            set => SetPropertyValue(nameof(ActionType), value);
        }

        [Parameter]
        public Align Align
        {
            get => GetPropertyValue<Align>(nameof(Align));
            set => SetPropertyValue(nameof(Align), value);
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string Class { get; set; }

        [Parameter]
        public object DataContext
        {
            get => GetPropertyValue<object>(nameof(DataContext));
            set
            {
                if (GetPropertyValue<object>(nameof(DataContext)) is INotifyPropertyChanged storedValueAsNotifyPropertyChanged)
                {
                    storedValueAsNotifyPropertyChanged.PropertyChanged -= OnDataContextPropertyChanged;
                }

                if (value is INotifyPropertyChanged valueAsNotifyPropertyChanged)
                {
                    valueAsNotifyPropertyChanged.PropertyChanged += OnDataContextPropertyChanged;
                }

                SetPropertyValue(nameof(DataContext), value);
            }
        }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Label { get; set; }

        protected List<ActionDefinition> ActionDefinitions
        {
            get
            {
                if (ActionSource is null || DataContext is null)
                {
                    return null;
                }

                return ActionSource(DataContext).ToList();
            }
        }

        private void OnDataContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }
    }
}
