namespace Blorc.PatternFly.Example.Components.Integration.TableIntegrationExample
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Example.Pages.Components;

    using Microsoft.AspNetCore.Components;

    public class TableIntegrationExampleComponent : BlorcComponentBase
    {
        private readonly Random _random = new Random();

        private ArrayList _data;

        public int Count { get { return _data.Count; } }

        [Parameter]
        public IEnumerable Data
        {
            get
            {
                return GetPropertyValue<IEnumerable>(nameof(Data));
            }

            set
            {
                SetPropertyValue(nameof(Data), value);
            }
        }

        public bool Loading { get; set; }

        public void Generate()
        {
            Load(0, 5);
        }

        protected override void OnInitialized()
        {
        base.OnInitialized();
            _data = new ArrayList();
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
                // Thread.Sleep(10);
            }
        }

        public void Load(int offset, int limit)
        {
            Loading = true;
            this.Limit = limit;
            Data = _data.OfType<object>().Skip(offset).Take(limit).ToList();
        }

        protected int Limit { get; set; }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(Data))
            {
                StateHasChanged();
            }
        }
    }
}
