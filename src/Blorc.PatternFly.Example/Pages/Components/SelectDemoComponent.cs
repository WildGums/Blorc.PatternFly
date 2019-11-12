using System;
using System.Collections.Generic;

namespace Blorc.PatternFly.Example.Pages.Components
{
    using Blorc.Components;

    public class SelectDemoComponent : BlorcComponentBase
    {
        public IReadOnlyDictionary<string, string> SelectedItems
        {
            get => GetPropertyValue<IReadOnlyDictionary<string, string>>(nameof(SelectedItems));
            set => SetPropertyValue(nameof(SelectedItems), value);
        }

        private void OnSingleSelectInputSelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Selection changed");
        }
    }
}
