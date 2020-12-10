using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace adventOfCode.cmd
{
    public static class Input {
        public static List<int> ReadInputAsListOfInt(string filename) {
            var input = new List<int>();

            using var fileStream = File.OpenRead(filename);
            using var streamReader = new StreamReader(fileStream);

            string line;
            while ((line = streamReader.ReadLine()) != null)
                input.Add(int.Parse(line));

            return input;
        }

        public static List<string> ReadInputAsListOfString(string filename) {
            var input = new List<string>();

            using var fileStream = File.OpenRead(filename);
            using var streamReader = new StreamReader(fileStream);

            string line;
            while ((line = streamReader.ReadLine()) != null)
                input.Add(line);

            return input;
        }

        public static string ReadInputAsString(string filename) {
            var input = new StringBuilder();

            using var fileStream = File.OpenRead(filename);
            using var streamReader = new StreamReader(fileStream);

            string line;
            while ((line = streamReader.ReadLine()) != null)
                input.Append($"{line}{Environment.NewLine}");

            return input.ToString();
        }
    }
}