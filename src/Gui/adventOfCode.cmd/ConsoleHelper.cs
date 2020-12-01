using System;

namespace adventOfCode.cmd
{
    public static class ConsoleHelper {
      public static void PrintHeader(string title) {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"-- {title}                         --");
            Console.WriteLine("----------------------------------------------");
        }
    }
}