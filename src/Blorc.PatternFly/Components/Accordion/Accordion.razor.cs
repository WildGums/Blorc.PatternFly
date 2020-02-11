namespace Blorc.PatternFly.Components.Accordion
{
    using Blorc.Components;
    using Microsoft.AspNetCore.Components;

    public class AccordionComponent : BlorcComponentBase
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
