namespace Blorc.PatternFly.Example.Pages.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.Table;

    using Microsoft.AspNetCore.Components;

    public class TabsDemoComponent : BlorcComponentBase
    {
        private readonly Random _random = new Random();

        public int SelectedId
        {
            get
            {
                return GetPropertyValue<int>(nameof(SelectedId));
            }

            set
            {
                SetPropertyValue(nameof(SelectedId), value);
            }
        }

        protected List<SortedDictionary<string, ColumnDefinition>> Columns { get; set; }

        protected List<ArrayList> Data { get; } = new List<ArrayList>();

        protected RenderFragment GetTable(int idx)
        {
            return builder =>
            {
                Console.WriteLine(Columns[idx].Count);

                builder.OpenComponent<Table>(0);
                builder.AddAttribute(1, nameof(Table.DataSource), Data[idx]);
                builder.AddAttribute(1, nameof(Table.ColumnDefinitions), Columns[idx]);
                builder.CloseComponent();
            };
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Columns = new List<SortedDictionary<string, ColumnDefinition>>();
            for (var i = 0; i < 3; i++)
            {
                var data = new ArrayList();
                for (var j = 0; j < 5; j++)
                {
                    data.Add(
                        new TableDemoComponent.Record
                        {
                            Repositories = $"one-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            Branches = $"two-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            PullRequests = $"three-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            Workspaces = $"four-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            LastCommit = $"five-{_random.Next(0, 100).ToString().PadLeft(2, '0')}"
                        });
                }

                Data.Add(data);

                var columnDefinitions = new SortedDictionary<string, ColumnDefinition>();

                columnDefinitions["Repositories"] = new ColumnDefinition { Idx = 0, Key = "Repositories", Label = "Repositories" };
                columnDefinitions["Branches"] = new ColumnDefinition { Idx = 1, Key = "Branches", Label = "Branches" };
                columnDefinitions["PullRequests"] = new ColumnDefinition { Idx = 2, Key = "PullRequests", Label = "Pull Requests" };
                if (i % 2 == 0)
                {
                    columnDefinitions["Workspaces"] = new ColumnDefinition { Idx = 3, Key = "Workspaces", Label = "Workspaces" };
                    columnDefinitions["LastCommit"] = new ColumnDefinition { Idx = 4, Key = "LastCommit", Label = "Last Commit" };
                }

                Columns.Add(columnDefinitions);
            }
        }
    }
}
