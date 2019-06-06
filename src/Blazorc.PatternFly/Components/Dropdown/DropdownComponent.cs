namespace Blazorc.PatternFly.Components.Dropdown
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class DropdownComponent : UniqueComponentBase
    {
        public DropdownComponent()
        {
            Position = DropdownPosition.Left;
            Direction = DropdownDirection.Down;

            ToggleId = GenerateUniqueId("pf-toggle-id");

            CreateConverter()
                .Fixed("pf-c-dropdown")
                .Update(() => Class);

            CreateConverter()
                .If(() => !IsOpen, "display: none")
                .Watch(() => IsOpen)
                .Update(() => OpenState);
        }

        public override string ComponentName => "toggle";

        public string Class { get; set; }

        public string OpenState { get; set; }

        [Parameter]
        public string ToggleId { get; set; }

        [Parameter]
        public bool IsOpen
        {
            get { return GetPropertyValue<bool>(nameof(IsOpen)); }
            set { SetPropertyValue(nameof(IsOpen), value); }
        }

        [Parameter]
        public bool IsPlain { get; set; }

        [Parameter]
        public DropdownPosition Position { get; set; }

        [Parameter]
        public DropdownDirection Direction { get; set; }

        [Parameter]
        public RenderFragment Toggle { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment Items { get; set; }

        [Parameter]
        public EventHandler<EventArgs> SelectionChanged { get; set; }
    }
}
