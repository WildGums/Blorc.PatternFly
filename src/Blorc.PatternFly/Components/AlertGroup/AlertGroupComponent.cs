namespace Blorc.PatternFly.Components.AlertGroup
{
    using System;
    using Alert;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;
    using StateConverters;

    public class AlertGroupComponent : BlorcComponentBase
    {

        public AlertGroupComponent()
        {
            CreateConverter()
                .Fixed("pf-c-alert")
                .If(() => AlertType == AlertType.Success, "pf-m-success")
                .If(() => AlertType == AlertType.Danger, "pf-m-danger")
                .If(() => AlertType == AlertType.Info, "pf-m-info")
                .Watch(() => AlertType)
                .Update(() => Class);

            CreateConverter()
                .If(() => AlertType == AlertType.Success, "Success Alert")
                .If(() => AlertType == AlertType.Danger, "Danger Alert")
                .If(() => AlertType == AlertType.Info, "Info Alert")
                .Watch(() => AlertType)
                .Update(() => AriaLabel);

            CreateConverter()
                .Fixed("fas")
                .If(() => AlertType == AlertType.Success, "fa-check-circle")
                .If(() => AlertType == AlertType.Danger, "fa-exclamation-circle")
                .If(() => AlertType == AlertType.Info, "fa-info-circle")
                .Watch(() => AlertType)
                .Update(() => AlertGroupIcon);
        }

        public string Class { get; set; }

        public string AriaLabel { get; set; }

        public string AlertGroupIcon { get; set; }

        [Parameter]
        public AlertType AlertType { get; set; } = AlertType.Info;

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public RenderFragment ActionContent { get; set; }

        [Parameter]
        public bool ShowCloseIconButton { get; set; }

        public bool IsClosed { get; set; }

        protected void Close()
        {
            IsClosed = true;
            StateHasChanged();
        }


    }
}
