namespace Blorc.PatternFly.Components.List
{
    using System;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class ListItem : BlorcComponentBase
    {
        public ListItem()
        {

        }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
