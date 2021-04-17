namespace Blorc.PatternFly.Components.Dropdown
{
    using System;
    using Blorc.Components;
    using Blorc.StateConverters;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;

    public partial class DropdownItem : BlorcComponentBase
    {
        public DropdownItem()
        {
            Component = "a";
            Index = -1;

            CreateConverter()
                .Fixed("pf-c-dropdown__menu-item")
                .If(() => IsDisabled, "pf-m-disabled")
                .Watch(() => IsDisabled)
                .Update(() => Class);
        }

        public string Class { get; set; }

        [Parameter]
        public string Component
        {
            get { return GetPropertyValue<string>(nameof(Component)); }
            set { SetPropertyValue(nameof(Component), value); }
        }

        [Parameter]
        public string Key
        {
            get { return GetPropertyValue<string>(nameof(Key)); }
            set { SetPropertyValue(nameof(Key), value); }
        }

        [Parameter]
        public bool IsDisabled
        {
            get { return GetPropertyValue<bool>(nameof(IsDisabled)); }
            set { SetPropertyValue(nameof(IsDisabled), value); }
        }

        [Parameter]
        public bool IsHovered
        {
            get { return GetPropertyValue<bool>(nameof(IsHovered)); }
            set { SetPropertyValue(nameof(IsHovered), value); }
        }

        [Parameter]
        public string Href
        {
            get { return GetPropertyValue<string>(nameof(Href)); }
            set { SetPropertyValue(nameof(Href), value); }
        }

        [Parameter]
        public int Index
        {
            get { return GetPropertyValue<int>(nameof(Index)); }
            set { SetPropertyValue(nameof(Index), value); }
        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventHandler<EventArgs> SelectionChanged { get; set; }

        [CascadingParameter]
        public Dropdown ContainerDropdown { get; set; }

        protected void OnButtonClicked(MouseEventArgs e)
        {
            var handler = OnClick;
            if (handler is not null)
            {
                handler(this, EventArgs.Empty);
            }

            if (ContainerDropdown is not null)
            {
                ContainerDropdown.Close();
            }
        }

        [Parameter]
        public EventHandler<EventArgs> OnClick { get; set; }

        protected RenderFragment CustomRender;

        private RenderFragment CreateComponent() => builder =>
        {
            int idx = 0;
            builder.OpenElement(idx++, Component);

            builder.AddAttribute(idx++, "role", "menuitem");
            builder.AddAttribute(idx++, "class", Class);


            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(idx++, "href", Href);
            }

            if (OnClick is not null)
            {
                builder.AddAttribute(idx++, "onclick", new EventCallback<MouseEventArgs>(this, new Action<MouseEventArgs>(OnButtonClicked)));
            }

            builder.AddAttribute(idx++, "tabindex", Index);
            builder.AddAttribute(idx++, "disabled", IsDisabled);

            builder.AddContent(idx, ChildContent);
            builder.CloseElement();
        };


        protected override void OnInitialized()
        {
            base.OnInitialized();

            CustomRender = CreateComponent();
        }
    }
}
