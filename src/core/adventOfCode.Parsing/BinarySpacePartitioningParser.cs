using System;
using System.Collections.Generic;
using System.Linq;
using adventOfCode.Domain;
using adventOfCode.Domain.Interfaces;
using adventOfCode.Application;
using adventOfCode.Application.Extensions;

namespace adventOfCode.Parsing
{
    public class BinarySpacePartitioningParser : IParser<string, Seat>
    {
        public Seat Parse(string value)
        {
            List<char> rowInstructions = value.Substring(0, 7).ToList();
            List<char> colInstructions = value.Last(3).ToList();

            var seat = new Seat();

            seat.Row = ExecuteInstructions(rowInstructions);
            seat.Column = ExecuteInstructions(colInstructions);

            return seat;
        }

        private int ExecuteInstructions(List<char> instructions)
        {
            int min = 0;
            int max = Convert.ToInt32(Math.Pow(2, instructions.Count)) - 1;

            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                    case 'F':
                        max = ((max - min) / 2) + min;

                        break;
                    case 'R':
                    case 'B':
                        min = max - ((max - min) / 2);
                        break;
                }
            }

            if (instructions[^1] == 'L' || instructions[^1] == 'F')
                return min;

            return max;
        }
    }
}
