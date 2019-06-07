namespace Blazorc.PatternFly.Components.Progress
{
    using System;
    using System.Collections.Generic;
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class ProgressComponent : UniqueComponentBase
    {
        public ProgressComponent()
        {
            Size = ProgressSize.Normal;
            MeasureLocation = ProgressMeasureLocation.Top;
            Variant = ProgressVariant.Info;
            Min = 0;
            Max = 100;
        }

        public override string ComponentName => "progress";

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public ProgressSize Size { get; set; }

        public string SizeText
        {
            get
            {
                switch (Size)
                {
                    case ProgressSize.Small:
                        return "sm";

                    case ProgressSize.Large:
                        return "lg";

                    default:
                        return string.Empty;
                }
            }
        }

        [Parameter]
        public ProgressMeasureLocation MeasureLocation { get; set; }

        [Parameter]
        public ProgressVariant Variant { get; set; }

        [Parameter]
        public int Min { get; set; }

        [Parameter]
        public int Max { get; set; }

        [Parameter]
        public int Value { get; set; }

        public string Class
        {
            get
            {
                var items = new List<string>();

                switch (Size)
                {
                    case ProgressSize.Small:
                        items.Add($"pf-m-sm");
                        break;

                    case ProgressSize.Large:
                        items.Add($"pf-m-lg");
                        break;
                }

                switch (MeasureLocation)
                {
                    case ProgressMeasureLocation.Inside:
                        items.Add($"pf-m-inside");
                        break;

                    case ProgressMeasureLocation.Outside:
                        items.Add($"pf-m-outside");
                        break;
                }

                switch (Variant)
                {
                    case ProgressVariant.Success:
                        items.Add($"pf-m-success");
                        break;

                    case ProgressVariant.Danger:
                        items.Add($"pf-m-danger");
                        break;
                }

                return string.Join(" ", items);
            }
        }

        public string TitleStyle
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    return $"display: none";
                }

                return string.Empty;
            }
        }

        public string ValueStyle
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ValueText))
                {
                    return $"display: none";
                }

                return string.Empty;
            }
        }

        public string SuccessIconStyle
        {
            get
            {
                if (Variant != ProgressVariant.Success)
                {
                    return $"display: none";
                }

                return string.Empty;
            }
        }

        public string DangerIconStyle
        {
            get
            {
                if (Variant != ProgressVariant.Danger)
                {
                    return $"display: none";
                }

                return string.Empty;
            }
        }

        public string InsideValue
        {
            get
            {
                if (MeasureLocation == ProgressMeasureLocation.None)
                {
                    return string.Empty;
                }

                if (MeasureLocation != ProgressMeasureLocation.Inside)
                {
                    return string.Empty;
                }

                return ValueText ?? $"{Value}%";
            }
        }

        public string OutsideValue
        {
            get
            {
                if (MeasureLocation == ProgressMeasureLocation.None)
                {
                    return string.Empty;
                }

                if (MeasureLocation == ProgressMeasureLocation.Inside)
                {
                    return string.Empty;
                }

                return ValueText ?? $"{Value}%";
            }
        }

        [Parameter]
        public string ValueText { get; set; }
    }
}
