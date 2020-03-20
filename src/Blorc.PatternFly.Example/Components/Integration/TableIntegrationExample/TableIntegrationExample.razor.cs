namespace Blorc.PatternFly.Example.Components.Integration.TableIntegrationExample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Components.List;
    using Blorc.PatternFly.Components.Page;
    using Blorc.PatternFly.Example.Pages.Components;

    using Microsoft.AspNetCore.Components;

    public class TableIntegrationExampleComponent : BlorcComponentBase
    {
        private readonly Random _random = new Random();

        private List<object> _data;

        public int Count { get { return _data.Count; } }

        [Parameter]
        public List<object> Data
        {
            get
            {
                return GetPropertyValue<List<object>>(nameof(Data));
            }

            set
            {
                SetPropertyValue(nameof(Data), value);
            }
        }

        public bool Loading
        {
            get
            {
                return GetPropertyValue<bool>(nameof(Loading));
            }

            set
            {
                SetPropertyValue(nameof(Loading), value);
            }
        }

        public void Generate()
        {
            Load(0, 0, 5);
           
        }

        protected override void OnInitialized()
        {
        base.OnInitialized();
            _data = new List<object>();
            for (var i = 0; i < 100; i++)
            {
                _data.Add(
                    new TableDemoComponent.Record
                    {
                        Repositories = $"one-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                        Branches = $"two-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                        PullRequests = $"three-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                        Workspaces = $"four-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                        LastCommit = $"five-{_random.Next(0, 100).ToString().PadLeft(2, '0')}"
                    });
            }
        }

        public Task Load(int page, int offset, int limit)
        {
            Console.WriteLine($"Loading {page} {offset} {limit}...");

            PageIndex = page;
            Limit = limit;
            
            Loading = true;
            
            Task.Run(
                async () =>
                {
                    await Task.Delay(1000);
                    Data = _data.OfType<object>().Skip(offset).Take(limit).ToList();
                    Loading = false;
                });
            
            return Task.CompletedTask;
        }

        protected int Limit { get; set; }

        protected int PageIndex { get; set; }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(Loading) && Loading)
            {
                Data = null;
            }
            else if (e.PropertyName == nameof(Data))
            {
                StateHasChanged();
            }
        }
    }
}
