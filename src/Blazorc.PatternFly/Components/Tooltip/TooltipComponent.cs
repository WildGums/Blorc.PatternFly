namespace Blazorc.PatternFly.Components.Tooltip
{
    using System;
    using Microsoft.AspNetCore.Components;

    public class TooltipComponent : ComponentBase
    {
        public TooltipComponent()
        {
            Position = TooltipPosition.Top;
            Trigger = TooltipTrigger.Click | TooltipTrigger.MouseEnter;
            EnableFlip = true;
            EntryDelay = 500;
            ExitDelay = 500;
            ZIndex = 9999;
            MaxWidth = "12.5rem";
        }

        [Parameter]
        public TooltipPosition Position { get; set; }

        [Parameter]
        public TooltipTrigger Trigger { get; set; }

        [Parameter]
        public bool EnableFlip { get; set; }

        [Parameter]
        public double EntryDelay { get; set; }

        [Parameter]
        public double ExitDelay { get; set; }

        [Parameter]
        public int ZIndex { get; set; }

        [Parameter]
        public string MaxWidth { get; set; }

        [Parameter]
        public RenderFragment TooltipContent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
