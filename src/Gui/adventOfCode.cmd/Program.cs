using System;
using System.Collections.Generic;

using adventOfCode.Application;

namespace adventOfCode.cmd
{
    public class Program
    {
        static void Main(string[] args) {
            Day1(Input.ReadExpenses(@"assets\input\day1.txt"));
        }

        static void Day1(List<int> expenses) {
            ConsoleHelper.PrintHeader("DAY 01 - part 01");
            var answer = Expenses.ProductOfTwoEntries(expenses, 2020);
            Console.WriteLine($"Answer: {answer}");

            ConsoleHelper.PrintHeader("DAY 01 - part 02");
            answer = Expenses.ProductOfThreeEntries(expenses, 2020);
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
