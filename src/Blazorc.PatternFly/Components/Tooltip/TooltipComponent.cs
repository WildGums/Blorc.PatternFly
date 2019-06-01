namespace Blazorc.PatternFly.Components.Tooltip
{
    using System;
    using System.Threading.Tasks;
    using Blazor.PatternFly;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

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

        protected bool IsVisible { get; set; }

        protected string X { get; private set; }

        protected string Y { get; private set; }

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

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        protected Guid Id { get; } = Guid.NewGuid();

        protected string GetPositionClass()
        {
            switch (Position)
            {
                case TooltipPosition.Bottom:
                    return "pf-m-bottom";
                case TooltipPosition.Left:
                    return "pf-m-left";
                case TooltipPosition.Right:
                    return "pf-m-right";
                default:
                    return "pf-m-top";
            }
        }

        protected override void OnInit()
        {
            //_timer.Elapsed += OnTimerElapsed;
        }

        public void Dispose()
        {
        }

        protected void OnMouseOut(UIMouseEventArgs e)
        {
            HideTooltip();
        }

        protected async Task OnMouseEnter(UIMouseEventArgs e)
        {
            var boundingClientRect = await ElementsFunctionsInterop.GetOffsetBoundingClientRect(JsRuntime, e.ClientX, e.ClientY);

            Console.WriteLine(boundingClientRect.X + " " + boundingClientRect.Y + " " + boundingClientRect.Width + " " + boundingClientRect.Height + " " + boundingClientRect.Bottom + " " + boundingClientRect.Top);
            // TODO: We need to compute the coordinates well.

            const int ToolTipHeight = 80; // How to compute this?
            const int ToolTipWidth = 300; // How to compute this?
            const int ArrowSize = 20;

            if (Position == TooltipPosition.Top)
            {
                var x = boundingClientRect.X - boundingClientRect.Width / 2;
                X = x + "px";
                var y = boundingClientRect.Y - ToolTipHeight - ArrowSize;
                Y = y + "px";
            }

            if (Position == TooltipPosition.Bottom)
            {
                var x = boundingClientRect.X - boundingClientRect.Width / 2;
                X = x + "px";
                var y = boundingClientRect.Y + boundingClientRect.Height + ArrowSize; 
                Y = y + "px";
            }

            if (Position == TooltipPosition.Right)
            {
                var x = boundingClientRect.X + boundingClientRect.Width + ArrowSize;
                X = x + "px";
                var y = boundingClientRect.Y  + boundingClientRect.Height / 2 - ToolTipHeight / 2;
                Y = y + "px";
            }

            if (Position == TooltipPosition.Left)
            {
                var x = boundingClientRect.X - ToolTipWidth - ArrowSize;
                X = x + "px";
                var y = boundingClientRect.Y + boundingClientRect.Height / 2 - ToolTipHeight / 2;
                Y = y + "px";
            }

            if (!Trigger.HasFlag(TooltipTrigger.MouseEnter))
            {
                return;
            }

            ShowTooltip();
        }

        protected void OnClick(UIMouseEventArgs e)
        {
            if (!Trigger.HasFlag(TooltipTrigger.Click))
            {
                return;
            }

            ShowTooltip();
        }

        protected void OnFocus(UIFocusEventArgs e)
        {
            if (!Trigger.HasFlag(TooltipTrigger.Focus))
            {
                return;
            }

            ShowTooltip();
        }

        protected void ShowTooltip()
        {
            if (IsVisible)
            {
                return;
            }

            IsVisible = true;

            StateHasChanged();
        }

        protected void HideTooltip()
        {
            if (!IsVisible)
            {
                return;
            }

            IsVisible = false;

            StateHasChanged();
        }
    }
}
