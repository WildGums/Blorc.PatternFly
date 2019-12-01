namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Table;

    public class TableDemoComponent : BlorcComponentBase
    {
        private ArrayList _data;

        public TableComponent FiltrableTable { get; set; }

        public string FilterText
        {
            get => GetPropertyValue<string>(nameof(FilterText));
            set => SetPropertyValue(nameof(FilterText), value);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(FilterText))
            {
                
                FiltrableTable.Refresh();
            }
        }

        public IEnumerable<ActionDefinition> GetActions(object row)
        {
            // This parameter allow customization per row state.
            var actionDefinitions = new List<ActionDefinition>();
            if (row is Record record)
            {
                actionDefinitions.Add(
                    new CallActionDefinition { Label = "Print Repositories", Action = PrintRepositories });
                actionDefinitions.Add(new SeparatorActionDefinition());
                actionDefinitions.Add(
                    new CallActionDefinition { Label = "Print Branches", Action = PrintBranches });
                actionDefinitions.Add(
                    new CallActionDefinition { Label = "Disabled Call", IsDisabled = true });
                return actionDefinitions;
            }

            return actionDefinitions;
        }

        public IEnumerable GetData()
        {
            if (_data == null)
            {
                _data = new ArrayList();
                var random = new Random();
                for (var i = 0; i < 5; i++)
                {
                    _data.Add(
                        new Record
                        {
                            Repositories = $"one-{random.Next(0, 100)}",
                            Branches = $"two-{random.Next(0, 100)}",
                            PullRequests = $"three-{random.Next(0, 100)}",
                            Workspaces = $"four-{random.Next(0, 100)}",
                            LastCommit = $"five-{random.Next(0, 100)}"
                        });
                }
            }

            return _data;
        }

        private void PrintBranches(object obj)
        {
            if (obj is Record record)
            {
                Console.WriteLine($"Branches: {record.Branches}");
            }
        }

        private void PrintRepositories(object obj)
        {
            if (obj is Record record)
            {
                Console.WriteLine($"Repositories: {record.Repositories}");
            }
        }

        public class Record
        {
            public string Branches { get; set; }

            public string LastCommit { get; set; }

            public string PullRequests { get; set; }

            public string Repositories { get; set; }

            public string Workspaces { get; set; }
        }
    }
}
