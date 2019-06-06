namespace Blazorc.PatternFly.Components
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public abstract class UniqueComponentBase : BlazorcComponentBase
    {

        public UniqueComponentBase()
        {
            InstanceId = GenerateUniqueId(ComponentName?.ToLower());
        }

        public string InstanceId { get; private set; }

        public abstract string ComponentName { get; }
    }
}
