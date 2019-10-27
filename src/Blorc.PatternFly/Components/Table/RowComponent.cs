namespace Blorc.PatternFly.Components.Table
{
    using System.Collections;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class RowComponent : BlorcComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public string Class { get; set; }

    }
}
