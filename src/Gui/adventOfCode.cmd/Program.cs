using System;
using System.Collections.Generic;

using adventOfCode.Application;

namespace adventOfCode.cmd
{
    public class Program
    {
        static void Main(string[] args)
        {
            Day1();

            // Console.WriteLine("\n\n----------------------------------------------");
            // Console.WriteLine("Press anykey to quit...");
            // Console.ReadLine();
        }

        static void Day1() {
            PrintHeader("DAY 01 - part 01");
            var expenses = Input.ReadExpenses(@"assets\input\day1.txt");
            var answer = Expenses.FixExpenseReport(expenses, 2020);

            Console.WriteLine($"Answer: {answer}");
        }

        static void PrintHeader(string title) {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"-- {title}                         --");
            Console.WriteLine("----------------------------------------------");
        }
    }
}
