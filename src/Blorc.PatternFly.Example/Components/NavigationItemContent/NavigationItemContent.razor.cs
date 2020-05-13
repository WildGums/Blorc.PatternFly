namespace Blorc.PatternFly.Example.Components.NavigationItemContent
{
    using System.ComponentModel;

    using Blorc.Components;

    using Microsoft.AspNetCore.Components;

    public class NavigationItemContentComponent : BlorcComponentBase
    {
        [Parameter]
        public string Text
        {
            get => GetPropertyValue<string>(nameof(Text));
            set => SetPropertyValue(nameof(Text), value);
        }

        [Parameter]
        public ItemType ItemType
        {
            get => GetPropertyValue<ItemType>(nameof(ItemType));
            set => SetPropertyValue(nameof(ItemType), value);
        }
    }

    public enum ItemType
    {
        Unchanged,

        New,

        Updated,

        Unavailable
    }
}
