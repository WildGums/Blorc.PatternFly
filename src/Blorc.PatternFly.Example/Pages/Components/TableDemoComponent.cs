namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Blorc.Components;
    using PatternFly.Components.Table;

    public class TableDemoComponent : BlorcComponentBase
    {
        private ArrayList _data;

        public IEnumerable GetData()
        {
            if (_data == null)
            {
                _data = new ArrayList();
                var random = new Random();
                for (var i = 0; i < 5; i++)
                {
                    _data.Add(new Record
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

        public IEnumerable<ActionDefinition> GetActions(object row)
        {
            // This parameter allow customization per row state.
            var actionDefinitions = new List<ActionDefinition>();
            if (row is Record record)
            {
                actionDefinitions.Add(
                    new CallActionDefinition
                    {
                        Label = "Print Repositories", Action = PrintRepositories
                    });
                actionDefinitions.Add(new SeparatorActionDefinition());
                actionDefinitions.Add(
                    new CallActionDefinition
                    {
                        Label = "Print Branches", Action = PrintBranches
                    });
                actionDefinitions.Add(
                    new CallActionDefinition
                    {
                        Label = "Disabled Call", IsDisabled = true
                    });
                return actionDefinitions;
            }

            return actionDefinitions;
        }

        private void PrintRepositories(object obj)
        {
            if (obj is Record record)
            {
                Console.WriteLine($"Repositories: {record.Repositories}");
            }
        }

        private void PrintBranches(object obj)
        {
            if (obj is Record record)
            {
                Console.WriteLine($"Branches: {record.Branches}");
            }
        }

        public class Record
        {
            public string Repositories { get; set; }

            public string Branches { get; set; }

            public string PullRequests { get; set; }

            public string Workspaces { get; set; }

            public string LastCommit { get; set; }
        }
    }
}
