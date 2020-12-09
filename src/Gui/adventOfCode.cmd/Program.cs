using System;
using System.Collections.Generic;
using System.Linq;
using adventOfCode.Application;
using adventOfCode.Application.PasswordPolicies;
using adventOfCode.Application.Validators;
using adventOfCode.Domain;
using adventOfCode.Serialization;

namespace adventOfCode.cmd
{
    public class Program
    {
        static void Main(string[] args) {
            Day1(Input.ReadInputAsListOfInt(@"assets\input\day1.txt"));
            Day2(Input.ReadInputAsListOfString(@"assets\input\day2.txt"));
            Day3(Input.ReadInputAsListOfString(@"assets\input\day3.txt"));
            Day4(Input.ReadInputAsString(@"assets\input\day4.txt"));
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

            List<Slope> slopes = new List<Slope>()
            {
                new Slope(right: 1, down: 1),
                new Slope(right: 3, down: 1),
                new Slope(right: 5, down: 1),
                new Slope(right: 7, down: 1),
                new Slope(right: 1, down: 2)
            };

            ConsoleHelper.PrintHeader("DAY 03 - part 02");
            map = new Map(mapInput);
            long answerPart2 = map.Benchmark(slopes);
            Console.WriteLine($"Answer: {answerPart2}");
        }

        static void Day4(string passportsInput)
        {
            PassportSerializer serializer = new PassportSerializer();
            List<Passport> passports = serializer.Deserialize<Passport>(passportsInput).ToList();

            ConsoleHelper.PrintHeader("DAY 04 - part 01");
            var handler = new PassportHandler(passports, new PassportValidator());
            int answer = handler.ValidPassportsCount();
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
