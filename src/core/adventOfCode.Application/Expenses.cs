using System;
using System.Collections.Generic;

namespace adventOfCode.Application
{
  public static class Expenses
  {
      public static int FixExpenseReport(List<int> report, int targetSum){
        report.Sort();

        int leftPointer = 0;
        int rightPointer = report.Count - 1;
        int answer = report[leftPointer] + report[rightPointer];

        while (leftPointer < rightPointer && answer != targetSum) {
          if (answer < targetSum){
            leftPointer++;
          } else {
            rightPointer--;
          }
          answer = report[leftPointer] + report[rightPointer];
        }

        return report[leftPointer] * report[rightPointer];
      }
  }
}