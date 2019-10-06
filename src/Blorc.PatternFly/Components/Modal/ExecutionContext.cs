// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PleaseWaitModalExecutionContext.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.Modal
{
    using System;
    
    public class ExecutionContext
    {
        public ExecutionContext(IProgress<int> progress, object state)
        {
            Progress = progress;
            State = state;
        }

        public IProgress<int> Progress { get; }

        public object State { get; }
    }
}
