namespace Blorc.PatternFly.Components.AlertGroup
{
    using System;
    using Blorc.Components;

    public class ContainerConfiguration : BlorcComponentBase
    {
        private AlertGroupContainerPositionType _positionType;

        public string PositionClass { get; set; }

        public AlertGroupContainerPositionType PositionType
        {
            get { return _positionType; }
            set
            {
                _positionType = value;
                switch (_positionType)
                {
                    case AlertGroupContainerPositionType.BottomCenter:
                        PositionClass = "toast-bottom-center";
                        break;
                    case AlertGroupContainerPositionType.TopCenter:
                        PositionClass = "toast-top-center";
                        break;
                    case AlertGroupContainerPositionType.TopFullWidth:
                        PositionClass = "toast-top-full-width";
                        break;
                    case AlertGroupContainerPositionType.BottomFullWidth:
                        PositionClass = "toast-bottom-full-width";
                        break;
                    case AlertGroupContainerPositionType.TopLeft:
                        PositionClass = "toast-top-left";
                        break;
                    case AlertGroupContainerPositionType.TopRight:
                        PositionClass = "toast-top-right"; ;
                        break;
                    case AlertGroupContainerPositionType.BottomLeft:
                        PositionClass = "toast-bottom-left";
                        break;
                    case AlertGroupContainerPositionType.BottomRight:
                        PositionClass = "toast-bottom-right";
                        break;
                }
            }
        }

        public ContainerConfiguration()
        {
            PositionType = AlertGroupContainerPositionType.BottomRight;
        }

    }
}
