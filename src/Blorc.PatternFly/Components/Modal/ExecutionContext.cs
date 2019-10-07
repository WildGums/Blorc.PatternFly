// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PleaseWaitModalExecutionContext.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Blorc.PatternFly.Components.Modal
{
    using System;
    using Core;

    public class ExecutionContext
    {
        public ExecutionContext(IProgressAsync<int> progress, object state)
        {
            Progress = progress;
            State = state;
        }

        public IProgressAsync<int> Progress { get; }

        public object State { get; }
    }
}
