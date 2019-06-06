namespace Blazorc.PatternFly.Components.Select

{
    using Microsoft.AspNetCore.Components;

    public class SingleSelectComponent : BlazorcComponentBase
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
