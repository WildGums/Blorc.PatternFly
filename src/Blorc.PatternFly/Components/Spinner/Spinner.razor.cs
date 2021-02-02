namespace Blorc.PatternFly.Components.Spinner

{
    using Blorc.Components;
    using Blorc.StateConverters;

    using Microsoft.AspNetCore.Components;

    public partial class Spinner : BlorcComponentBase
    {
        public Spinner()
        {
            CreateConverter()
                .Fixed("pf-c-spinner")
                .If(() => Size == SpinnerSize.Small, "pf-m-sm")
                .If(() => Size == SpinnerSize.Medium, "pf-m-md")
                .If(() => Size == SpinnerSize.Large, "pf-m-lg")
                .If(() => Size == SpinnerSize.XLarge, "pf-m-xl")
                .Watch(() => Size)
                .Update(() => Class);
        }

        public string Class
        {
            get
            {
                return GetPropertyValue<string>(nameof(Class));
            }

            set
            {
                SetPropertyValue(nameof(Class), value);
            }
        }

        [Parameter]
        public bool IsVisible
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsVisible));
            }

            set
            {
                SetPropertyValue(nameof(IsVisible), value);
            }
        }

        [Parameter]
        public SpinnerSize Size
        {
            get
            {
                return GetPropertyValue<SpinnerSize>(nameof(Size));
            }

            set
            {
                SetPropertyValue(nameof(Size), value);
            }
        }
    }
}
