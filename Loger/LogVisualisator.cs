using Loger.Enums;
using System;

namespace Loger
{
    public class LogVisualisator
    {
        public static void Log(LogType type, string message)
        {
            switch(type)
            { 
                case LogType.Error:
                    LogError(message);
                    break;
                case LogType.Warning:
                    LogWarning(message);
                    break;
                case LogType.Info:
                    LogInfo(message);
                    break;
            }
        }

        private static void LogError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] => {message}");
            Console.ResetColor();
        }
        public static void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Warning] => {message}");
            Console.ResetColor();
        }
        public static void LogInfo(string message)
        {
            Console.WriteLine($"[Info] => {message}");
        }
    }
}
