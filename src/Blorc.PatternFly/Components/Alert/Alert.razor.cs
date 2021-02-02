namespace Blorc.PatternFly.Components.Alert
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class Alert : BlorcComponentBase
    {
        [Parameter]
        public AlertType AlertType { get; set; } = AlertType.Danger;

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment Description { get; set; }

        [Parameter]
        public RenderFragment ActionContent { get; set; }

        [Parameter]
        public bool ShowCloseActionButton { get; set; }

        public bool IsClosed { get; private set; }

        protected void Close()
        {
            IsClosed = true;
            StateHasChanged();
        }

        protected string GetAlertClass()
        {
            switch (AlertType)
            {
                case AlertType.Info:
                    return "pf-m-info";

                case AlertType.Success:
                    return "pf-m-success";

                case AlertType.Warning:
                    return "pf-m-warning";

                default:
                    return "pf-m-danger";
            }
        }

        protected string GetAlertIcon()
        {
            switch (AlertType)
            {
                case AlertType.Info:
                    return "fa-info-circle";

                case AlertType.Success:
                    return "fa-check-circle";

                case AlertType.Warning:
                    return "fa-exclamation-triangle";

                default:
                    return "fa-exclamation-circle";
            }
        }
    }
}
