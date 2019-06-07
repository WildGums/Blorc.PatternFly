namespace Blazorc.PatternFly.Components.Accordion
{
    using Blazorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AccordionComponent : BlazorcComponentBase
    {
        private int _selectedIndex;

        [Parameter]
        public RenderFragment Items { get; set; }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                }
                else
                {
                    _selectedIndex = -1;
                }

                StateHasChanged();
            }
        }
    }
}
