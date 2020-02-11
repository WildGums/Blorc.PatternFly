namespace Blorc.PatternFly.Components.ApplicationLauncher
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Blorc.PatternFly.Components.Dropdown;
    using Microsoft.AspNetCore.Components;

    public class ApplicationLauncherComponent : BlorcComponentBase
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
