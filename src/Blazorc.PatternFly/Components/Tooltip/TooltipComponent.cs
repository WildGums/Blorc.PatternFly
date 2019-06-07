namespace Blazorc.PatternFly.Components.Tooltip
{
    using System;
    using System.Threading.Tasks;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;
    using Services;
    using Services.Interop;

    public class TooltipComponent : BlazorcComponentBase
    {
        private const int ArrowSize = 20;

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
        public IDocumentService DocumentService { get; set; }

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

        protected void OnMouseOut(UIMouseEventArgs e)
        {
            HideTooltip();
        }

        protected async Task OnMouseEnter(UIMouseEventArgs e)
        {
            var tooltipRect = await DocumentService.GetBoundingClientRectById(Id.ToString());
            var tooltipRectHeight = tooltipRect.Height;
            var tooltipRectWidth = tooltipRect.Width;

            Rect boundingClientRect = await DocumentService.GetOffsetBoundingClientRect(e.ClientX, e.ClientY);
            switch (Position)
            {
                case TooltipPosition.Top:
                    X = boundingClientRect.X + boundingClientRect.Width / 2 - tooltipRectWidth / 2 + "px";
                    Y = boundingClientRect.Y - tooltipRectHeight - ArrowSize + "px";
                    break;
                case TooltipPosition.Bottom:
                    X = boundingClientRect.X + boundingClientRect.Width / 2 - tooltipRectWidth / 2 + "px";
                    Y = boundingClientRect.Y + boundingClientRect.Height + ArrowSize + "px";
                    break;
                case TooltipPosition.Right:
                    X = boundingClientRect.X + boundingClientRect.Width + ArrowSize + "px";
                    Y = boundingClientRect.Y + boundingClientRect.Height / 2 - tooltipRectHeight / 2 + "px";
                    break;
                case TooltipPosition.Left:
                    X = boundingClientRect.X - tooltipRectWidth - ArrowSize + "px";
                    Y = boundingClientRect.Y + boundingClientRect.Height / 2 - tooltipRectHeight / 2 + "px";
                    break;
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
