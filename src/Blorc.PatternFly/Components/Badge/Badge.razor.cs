namespace Blorc.PatternFly.Components.Badge
{
    using System;
    using System.Collections.Generic;
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public partial class Badge : BlorcComponentBase
    {
        public Badge()
        {

        }

        public string Class
        {
            get
            {
                var items = new List<string>();

                if (IsRead)
                {
                    items.Add("pf-m-read");
                }
                else
                {
                    items.Add("pf-m-unread");
                }

                return string.Join(" ", items);
            }
        }

        [Parameter]
        public bool IsRead { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
