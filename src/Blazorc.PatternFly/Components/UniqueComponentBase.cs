namespace Blazorc.PatternFly.Components
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public abstract class UniqueComponentBase : ComponentBase
    {
        private static readonly Dictionary<string, int> InstanceCounters = new Dictionary<string, int>();

        public UniqueComponentBase()
        {
            InstanceId = GenerateUniqueId(ComponentName?.ToLower());
        }

        public string InstanceId { get; private set; }

        public abstract string ComponentName { get; }

        protected string GenerateUniqueId(string prefix)
        {
            if (InstanceCounters.TryGetValue(prefix, out var index))
            {
            }

            InstanceCounters[prefix] = ++index;

            return $"{prefix}-{index}";
        }
    }
}
