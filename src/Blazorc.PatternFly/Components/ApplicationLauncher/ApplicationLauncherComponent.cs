namespace Blazorc.PatternFly.Components.ApplicationLauncher
{
    using System;
    using System.Collections.Generic;
    using Blazorc.PatternFly.Components.Dropdown;
    using Microsoft.AspNetCore.Components;

    public class ApplicationLauncherComponent : BlazorcComponentBase
    {
        public ApplicationLauncherComponent()
        {
            IsPlain = true;
            Direction = DropdownDirection.Down;
            Position = DropdownPosition.Right;
        }

        [Parameter]
        public bool IsOpen { get; set; }

        [Parameter]
        public bool IsPlain { get; set; }

        [Parameter]
        public DropdownDirection Direction { get; set; }

        [Parameter]
        public DropdownPosition Position { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
