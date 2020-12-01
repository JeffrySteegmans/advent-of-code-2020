using System;
using System.Collections.Generic;
using Xunit;

using adventOfCode.Application;

namespace adventOfCode.tests
{
    public class Day01
    {
      private List<int> expenses = new List<int>(){
        1721,
        979,
        366,
        299,
        675,
        1456
      };

      [Fact]
      public void ProductOfTwo_ShouldBe_514579()
      {
        Assert.Equal(514579, Expenses.ProductOfTwoEntries(expenses, 2020));
      }

      [Fact]
      public void ProductOfThree_ShouldBe_241861950()
      {
        Assert.Equal(241861950, Expenses.ProductOfThreeEntries(expenses, 2020));
      }
    }
}
