namespace Blorc.PatternFly.Components.Dropdown
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.ToggleComponentContainer;
    using Blorc.PatternFly.Core;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public class DropdownComponent : UniqueComponentBase, IToggleComponent
    {
        public DropdownComponent()
        {
            Position = DropdownPosition.Left;
            Direction = DropdownDirection.Down;

            ToggleId = GenerateUniqueId("pf-toggle-id");

            CreateConverter()
                .Fixed("pf-c-dropdown")
                .If(() => Direction == DropdownDirection.Up, "pf-m-top")
                .If(() => IsOpen, "pf-m-expanded")
                .Watch(() => Direction)
                .Watch(() => IsOpen)
                .Update(() => Class);

            CreateConverter()
                .Fixed("pf-c-dropdown__menu")
                .If(() => Position == DropdownPosition.Right, "pf-m-align-right")
                .Watch(() => Position)
                .Update(() => PopupClass);

            CreateConverter()
                .If(() => !IsOpen, "display: none")
                .Watch(() => IsOpen)
                .Update(() => OpenState);
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string Class { get; set; }

        public override string ComponentName => "toggle";

        [Parameter]
        public DropdownDirection Direction
        {
            get => GetPropertyValue<DropdownDirection>(nameof(Direction));
            set => SetPropertyValue(nameof(Direction), value);
        }

        [Parameter]
        public bool IsGrouped
        {
            get => GetPropertyValue<bool>(nameof(IsGrouped));
            set => SetPropertyValue(nameof(IsGrouped), value);
        }

        [Parameter]
        public bool IsOpen
        {
            get => GetPropertyValue<bool>(nameof(IsOpen));
            set => SetPropertyValue(nameof(IsOpen), value);
        }

        [Parameter]
        public bool IsPlain
        {
            get => GetPropertyValue<bool>(nameof(IsPlain));
            set => SetPropertyValue(nameof(IsPlain), value);
        }

        [Parameter]
        public RenderFragment Items { get; set; }

        public string OpenState { get; set; }

        public string PopupClass { get; set; }

        [Parameter]
        public DropdownPosition Position
        {
            get => GetPropertyValue<DropdownPosition>(nameof(Position));
            set => SetPropertyValue(nameof(Position), value);
        }

        [Parameter]
        public EventHandler<EventArgs> SelectionChanged { get; set; }

        [Parameter]
        public RenderFragment Toggle { get; set; }

        [CascadingParameter]
        public IToggleComponentContainer ToggleComponentContainer { get; set; }

        [Parameter]
        public EventHandler<EventArgs> Toggled { get; set; }

        [Parameter]
        public string ToggleId { get; set; }

        internal DropdownToggleComponent DropDownToggle
        {
            get => GetPropertyValue<DropdownToggleComponent>(nameof(DropDownToggle));
            set => SetPropertyValue(nameof(DropDownToggle), value);
        }

        public void Close()
        {
            IsOpen = false;
            //// TODO: This can be removed after a binding system fix.
            DropDownToggle?.Close();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            if (ToggleComponentContainer != null)
            {
                ToggleComponentContainer.Register(this);
                ToggleComponentContainer.ToogleComponentChanged += ToggleComponentContainerOnToogleComponentChanged;
            }
        }

        private void ToggleComponentContainerOnToogleComponentChanged(object sender, ToggleComponentChangedEventArg e)
        {
            if (e.ToggleComponent != this && IsOpen)
            {
                Close();
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName == nameof(DropDownToggle))
            {
                var toggle = DropDownToggle;
                if (toggle != null)
                {
                    toggle.Toggled += OnDropDownToggled;
                }
            }
        }

        protected virtual void OnToggled()
        {
            Toggled?.Invoke(this, EventArgs.Empty);
        }

        private void OnDropDownToggled(object sender, EventArgs e)
        {
            IsOpen = DropDownToggle.IsOpen;
            OnToggled();
        }
    }
}
