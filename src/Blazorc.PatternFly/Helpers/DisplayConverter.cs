namespace Blazorc.PatternFly
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class DisplayConverter
    {
        public static string GetDisplayMode(bool isVisible)
        {
            if (isVisible)
            {
                return string.Empty;
            }

            return $"display: none";
        }
    }
}
