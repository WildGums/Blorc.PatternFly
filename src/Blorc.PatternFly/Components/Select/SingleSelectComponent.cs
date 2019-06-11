namespace Blorc.PatternFly.Components.Select

{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class SingleSelectComponent : BlorcComponentBase
    {
        //public string Class
        //{
        //    get
        //    {
        //var items = new List<string>();


        //        return string.Join(" ", items);
        //    }
        //}

        [Parameter] public object SelectedItem { get; set; }

        [Parameter] public bool IsExpanded { get; set; }

        // Internal flag
        //[Parameter]
        //public bool IsOpenedOnEnter { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
