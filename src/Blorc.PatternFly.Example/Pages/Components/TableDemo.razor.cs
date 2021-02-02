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
    using Blorc.Reflection;

    public partial class TableDemo : BlorcComponentBase
    {
        private readonly Random _random = new Random();

        private ArrayList _data;

        private readonly Dictionary<object, List<ActionDefinition>> _actionDefinitionsCache = new Dictionary<object, List<ActionDefinition>>();

        public string FilterText
        {
            get => GetPropertyValue<string>(nameof(FilterText));
            set => SetPropertyValue(nameof(FilterText), value);
        }

        public Table FiltrableTable { get; set; }

        public IEnumerable<ActionDefinition> GetActions(object row)
        {
            if (!_actionDefinitionsCache.ContainsKey(row))
            {
                _actionDefinitionsCache[row] = new List<ActionDefinition>();
            }

            var actionDefinitions = _actionDefinitionsCache[row];
            if (actionDefinitions.Count == 0)
            {
                // This parameter allow customization per row state.
                if (row is Record record)
                {
                    actionDefinitions.Add(
                        new CallActionDefinition { Label = "Print Repositories", Action = PrintRepositories });
                    actionDefinitions.Add(new SeparatorActionDefinition());
                    actionDefinitions.Add(
                        new CallActionDefinition { Label = "Print Branches", Action = PrintBranches });
                    
                    var switchActionDefinition = new SwitchActionDefinition
                                                 {
                                                     Label = "Turn On",
                                                     DataContext = record,
                                                     Action = SwitchBranches
                                                 };

                    switchActionDefinition.PropertyChanged += (sender, args) =>
                    {
                        if (args.PropertyName == nameof(SwitchActionDefinition.IsChecked))
                        {
                            switchActionDefinition.Label = switchActionDefinition.IsChecked ? "Turn Off" : "Turn On";
                        }
                    };
                    actionDefinitions.Add(switchActionDefinition);

                    // actionDefinitions.Add(
                    // new CallActionDefinition { Label = "Disabled Call", IsDisabled = true });
                }
            }

            foreach (var actionDefinition in actionDefinitions)
            {
                yield return actionDefinition;
            }
        }

        public IEnumerable GetData(bool reload = false)
        {
            if (_data == null || reload)
            {
                _data = new ArrayList();
                for (var i = 0; i < 5; i++)
                {
                    _data.Add(
                        new Record
                        {
                            Repositories = $"one-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            Branches = $"two-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            PullRequests = $"three-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            Workspaces = $"four-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            LastCommit = $"five-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            Link = "https://github.com/WildGums/Blorc.PatternFly"
                        });
                }
            }

            return _data;
        }

        public string GetHighlightStyle(object record)
        {
            var idx = _data.IndexOf(record);
            if (idx % 2 == 0)
            {
                return "border-left: 3px solid var(--pf-global--primary-color--100);";
            }

            return "border-left: 3px solid var(--pf-global--danger-color--100);";
        }

        public void UpdateSingleRow()
        {
            var next = _random.Next(0, _data.Count);
            var record = _data[next] as Record;
            record.Repositories = $"one-{_random.Next(0, 100).ToString().PadLeft(2, '0')}";
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

        private void SwitchBranches(object obj, bool isChecked)
        {
            Console.WriteLine($"Switching... {isChecked}");
        }

        public class Record : INotifyPropertyChanged, IDictionary
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

            public string Link { get; set; }

            public int Count { get; }

            public bool IsFixedSize { get; }

            public bool IsReadOnly { get; }

            public bool IsSynchronized { get; }

            public ICollection Keys { get; }

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

            public object SyncRoot { get; }

            public ICollection Values { get; }

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

            public object this[object key]
            {
                get => PropertyHelper.GetPropertyValue(this, key.ToString());
                set => throw new NotImplementedException();
            }

            public void Add(object key, object value)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(object key)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            public IDictionaryEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public void Remove(object key)
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
