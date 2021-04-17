namespace Blorc.PatternFly.Components.Tooltip
{
    using System;
    using System.Threading.Tasks;
    using Blorc.Components;
    using Blorc.Services;
    using Blorc.Services.Interop;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;

    public partial class Tooltip : BlorcComponentBase
    {
        private const int ArrowSize = 20;

        public Tooltip()
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

        protected void OnMouseOut(MouseEventArgs e)
        {
            HideTooltip();
        }

        protected async Task OnMouseEnterAsync(MouseEventArgs e)
        {
            var tooltipRect = await DocumentService.GetBoundingClientRectByIdAsync(Id.ToString());
            var tooltipRectHeight = tooltipRect.Height;
            var tooltipRectWidth = tooltipRect.Width;

            var boundingClientRect = await DocumentService.GetOffsetBoundingClientRectAsync(e.ClientX, e.ClientY);

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

        protected void OnClick(MouseEventArgs e)
        {
            if (!Trigger.HasFlag(TooltipTrigger.Click))
            {
                return;
            }

            ShowTooltip();
        }

        protected void OnFocus(FocusEventArgs e)
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
