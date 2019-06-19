using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
	public class Problem31 : EulerProblem
	{
		private static List<int> denominations = new List<int> {1,2,5,10,20,50,100};
		public long Solve(string textfile = "")
		{
			var ways = 1;
			for (int i = 0; i < 7; ++i)
			{
				var numWays = getWays(200, i);
				Console.WriteLine($"Found {numWays} with maximum coin value {denominations[i]}");
				ways += numWays;
			}

			return ways;
		}

		public int getWays(int total, int maxDenominationIndex)
		{
			if (total == 0 || maxDenominationIndex == 0)
			{
				return 1;
			}
			var maxDenomination = denominations[maxDenominationIndex];
			var ways = 0;
			for (int i = 1; i <= total / maxDenomination; ++i)
			{
				ways += getWaysRec(total - (maxDenomination * i), maxDenominationIndex -1);
			}
			return ways;
		}

		public int getWaysRec(int total, int maxDenominationIndex)
		{
			if (total == 0 || maxDenominationIndex == 0)
			{
				return 1;
			}
			var maxDenomination = denominations[maxDenominationIndex];
			var ways = 0;
			for (int i = 0; i <= total / maxDenomination; ++i)
			{
				ways += getWaysRec(total - (maxDenomination * i), maxDenominationIndex - 1);
			}
			return ways;
		}
	}
}
