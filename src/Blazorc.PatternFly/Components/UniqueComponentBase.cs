namespace Blazorc.PatternFly.Components
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Components;

    public abstract class UniqueComponentBase : ComponentBase
    {
        private static int InstanceCounter;

        public UniqueComponentBase()
        {
            InstanceId = $"{ComponentName?.ToLower()}-{++InstanceCounter}"; 
        }

        public string InstanceId { get; private set; }

        public abstract string ComponentName { get; }
    }
}
