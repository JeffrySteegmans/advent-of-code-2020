using System;
using System.Collections.Generic;

namespace adventOfCode.Application
{
  public static class Expenses
  {
      public static int ProductOfTwoEntries(List<int> report, int targetSum) {
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

      public static int ProductOfThreeEntries(List<int> report, int targetSum) {
        report.Sort();

        for(int i = 0; i < report.Count -2; i++) {
          int left = i + 1;
          int right = report.Count - 1;

          while (left < right) {
            int currentSum = report[i] + report[left] + report[right];

            if (currentSum == targetSum)
              return report[i] * report[left] * report[right];

            if (currentSum > targetSum)
              right--;

            if (currentSum < targetSum)
              left++;
          }
        }

        return -1;
      }
  }
}