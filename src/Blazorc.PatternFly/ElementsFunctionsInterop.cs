// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementsFunctionsInterop.cs" company="WildGums">
//   Copyright (c) 2008 - 2019 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Blazor.PatternFly
{
    using System.Threading.Tasks;
    using Microsoft.JSInterop;

    public class ElementsFunctionsInterop
    {
        public static Task<Rect> GetBoundingClientRect(IJSRuntime jsRuntime, long x, long y)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "ElementsFunctions.getBoundingClientRect",
                x, y);
        }

        public static Task<Rect> GetOffsetBoundingClientRect(IJSRuntime jsRuntime, long x, long y)
        {
            return jsRuntime.InvokeAsync<Rect>(
                "ElementsFunctions.getOffsetBoundingClientRect",
                x, y);
        }
    }

    public class Rect
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Bottom { get; set; }

        public int Top { get; set; }
    }
}
