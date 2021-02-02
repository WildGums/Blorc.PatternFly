namespace Blorc.PatternFly.Example.Components.Integration.TableIntegrationExample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Example.Pages.Components;

    using Microsoft.AspNetCore.Components;

    public class TableIntegrationExampleComponent : BlorcComponentBase
    {
        private readonly Random _random = new Random();

        private List<object> _data;

        public int Count { get { return IsDataAvailable ? _data.Count : 0; } }

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

        public bool IsLoading
        {
            get
            {
                return GetPropertyValue<bool>(nameof(IsLoading));
            }

            set
            {
                SetPropertyValue(nameof(IsLoading), value);
            }
        }

        protected bool IsDataAvailable { get; set; }

        protected int Limit { get; set; }

        protected int PageIndex { get; set; }

        public void Generate()
        {
            IsDataAvailable = true;
            Load(0, 0, 5);
        }

        public Task Load(int page, int offset, int limit)
        {
            Console.WriteLine($"Loading {page} {offset} {limit}...");

            PageIndex = page;
            Limit = limit;

            IsLoading = true;

            Task.Run(
                async () =>
                {
                    await Task.Delay(1000);
                    Data = _data.OfType<object>().Skip(offset).Take(limit).ToList();
                    IsLoading = false;
                });

            return Task.CompletedTask;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (_data == null)
            {
                IsDataAvailable = false;
                _data = new List<object>();
                for (var i = 0; i < 100; i++)
                {
                    _data.Add(
                        new TableDemo.Record
                        {
                            Repositories = $"one-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            Branches = $"two-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            PullRequests = $"three-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            Workspaces = $"four-{_random.Next(0, 100).ToString().PadLeft(2, '0')}",
                            LastCommit = $"five-{_random.Next(0, 100).ToString().PadLeft(2, '0')}"
                        });
                }
            }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == nameof(IsLoading))
            {
                if (IsLoading)
                {
                    Data = null; // Invalidate data for the table.
                }
                else
                {
                    StateHasChanged();
                }
            }
            else if (e.PropertyName == nameof(Data))
            {
                StateHasChanged();
            }
        }
    }
}
