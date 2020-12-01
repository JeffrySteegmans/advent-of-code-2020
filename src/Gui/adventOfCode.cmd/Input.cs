using System;
using System.Collections.Generic;
using System.IO;

namespace adventOfCode.cmd
{
    public static class Input {
      public static List<int> ReadExpenses(string filename) {
        var expenses = new List<int>();

        using (var fileStream = File.OpenRead(filename))
        using (var streamReader = new StreamReader(fileStream)) {
          String line;
          while ((line = streamReader.ReadLine()) != null)
            expenses.Add(int.Parse(line));
        }

        return expenses;
      }
    }
}