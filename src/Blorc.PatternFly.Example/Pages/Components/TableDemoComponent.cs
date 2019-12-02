namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Table;
    using Blorc.PatternFly.Example.Annotations;

    public class TableDemoComponent : BlorcComponentBase
    {
        private ArrayList _data;

        public string FilterText
        {
            get => GetPropertyValue<string>(nameof(FilterText));
            set => SetPropertyValue(nameof(FilterText), value);
        }

        public TableComponent FiltrableTable { get; set; }

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

        public void UpdateSingleRow()
        {
            var next = _random.Next(0, _data.Count);
            var record = _data[next] as Record;
            record.Repositories = $"one-{_random.Next(0, 100)}";
        }

        private readonly Random _random = new Random();

        public IEnumerable GetData()
        {
            if (_data == null)
            {
                _data = new ArrayList();
           
                for (var i = 0; i < 5; i++)
                {
                    _data.Add(
                        new Record
                        {
                            Repositories = $"one-{_random.Next(0, 100)}",
                            Branches = $"two-{_random.Next(0, 100)}",
                            PullRequests = $"three-{_random.Next(0, 100)}",
                            Workspaces = $"four-{_random.Next(0, 100)}",
                            LastCommit = $"five-{_random.Next(0, 100)}"
                        });
                }
            }

            return _data;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(FilterText))
            {
                FiltrableTable.Refresh();
            }
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

        public class Record : INotifyPropertyChanged
        {
            private string _branches;

            private string _lastCommit;

            private string _pullRequests;

            private string _repositories;

            private string _workspaces;

            public event PropertyChangedEventHandler PropertyChanged;

            public string Branches
            {
                get => _branches;
                set
                {
                    if (value == _branches)
                    {
                        return;
                    }

                    _branches = value;
                    OnPropertyChanged();
                }
            }

            public string LastCommit
            {
                get => _lastCommit;
                set
                {
                    if (value == _lastCommit)
                    {
                        return;
                    }

                    _lastCommit = value;
                    OnPropertyChanged();
                }
            }

            public string PullRequests
            {
                get => _pullRequests;
                set
                {
                    if (value == _pullRequests)
                    {
                        return;
                    }

                    _pullRequests = value;
                    OnPropertyChanged();
                }
            }

            public string Repositories
            {
                get => _repositories;
                set
                {
                    if (value == _repositories)
                    {
                        return;
                    }

                    _repositories = value;
                    OnPropertyChanged();
                }
            }

            public string Workspaces
            {
                get => _workspaces;
                set
                {
                    if (value == _workspaces)
                    {
                        return;
                    }

                    _workspaces = value;
                    OnPropertyChanged();
                }
            }

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
