namespace Blorc.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Log
    {
        public static void Debug(string message)
        {
            Write($"[DEBUG] {message}");
        }

        public static void Info(string message)
        {
            Write($"[INFO] {message}");
        }

        public static void Warning(string message)
        {
            Write($"[WARNING] {message}");
        }

        public static void Error(string message)
        {
            Write($"[ERROR] {message}");
        }

        public static void Error(Exception ex, string message)
        {
            Write($"[ERROR] {message}: {ex.Message}");
        }

        private static void Write(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
        }
    }
}
