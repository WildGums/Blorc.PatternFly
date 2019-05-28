namespace Blazorc.PatternFly.Components.Accordion
{
    using Microsoft.AspNetCore.Components;

    public class AccordionComponent : ComponentBase
    {
        private int _selectedIndex;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

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
