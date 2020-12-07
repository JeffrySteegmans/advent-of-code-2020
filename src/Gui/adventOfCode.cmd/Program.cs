using System;
using System.Collections.Generic;

using adventOfCode.Application;
using adventOfCode.Application.PasswordPolicies;
using adventOfCode.Domain;

namespace adventOfCode.cmd
{
    public class Program
    {
        static void Main(string[] args) {
            Day1(Input.ReadInputAsListOfInt(@"assets\input\day1.txt"));
            Day2(Input.ReadInputAsListOfString(@"assets\input\day2.txt"));
            Day3(Input.ReadInputAsListOfString(@"assets\input\day3.txt"));
        }

        static void Day1(List<int> expenses) {
            ConsoleHelper.PrintHeader("DAY 01 - part 01");
            var answer = Expenses.ProductOfTwoEntries(expenses, 2020);
            Console.WriteLine($"Answer: {answer}");

            ConsoleHelper.PrintHeader("DAY 01 - part 02");
            answer = Expenses.ProductOfThreeEntries(expenses, 2020);
            Console.WriteLine($"Answer: {answer}");
        }

        static void Day2(List<string> passwords)
        {
            ConsoleHelper.PrintHeader("DAY 02 - part 01");
            var answer = Password.CountValidPasswords(new SledRentalPolicy(), passwords);
            Console.WriteLine($"Answer: {answer}");

            ConsoleHelper.PrintHeader("DAY 02 - part 02");
            answer = Password.CountValidPasswords(new TobogganPolicy(), passwords);
            Console.WriteLine($"Answer: {answer}");
        }

        static void Day3(List<string> mapInput)
        {
            Slope slope = new Slope(right: 3, down: 1);

            ConsoleHelper.PrintHeader("DAY 03 - part 01");
            var map = new Map(mapInput);
            map.TraverseDown(slope);
            var answer = map.TreeCount;
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
