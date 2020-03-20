namespace Blorc.PatternFly.Example.Components.Integration.TableIntegrationExample
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;

    using Blorc.Components;
    using Blorc.PatternFly.Example.Pages.Components;

    using Microsoft.AspNetCore.Components;

    public class TableIntegrationExampleComponent : BlorcComponentBase
    {
        private readonly Random _random = new Random();

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
            Loading = true;
            Data = null;

            Task.Run(
                () =>
                {
                    Thread.Sleep(2000);

                    var data = new ArrayList();
                    for (var i = 0; i < 5; i++)
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

                    Loading = false;
                    Data = data;
                });
        }

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
