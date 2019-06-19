using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
	public class Problem26 : EulerProblem
	{
		public long Solve(string textfile = "")
		{
			var maxNum = 0;
			var maxCycle = 1;
			for (int i = 2; i < 1000; ++i)
			{
				var cycle = getCycle(i);
				if (cycle > maxCycle)
				{
					maxNum = i;
					maxCycle = cycle;
				}
			}
			Console.WriteLine($"Max num is:{maxNum} with a cycle of {maxCycle}");
			return maxNum;
		}

		public int getCycle(int divisor)
		{
			var remaindersSeen = new HashSet<int>();
			var remainders = new List<int>();
			var remainder = 1;
			for (int i = 0; i <= divisor; ++i)
			{
				var newRemainder = (remainder * 10) % divisor;
				if (remaindersSeen.Contains(newRemainder))
				{
					return i - remainders.IndexOf(newRemainder);
				}
				if (newRemainder == 0)
				{
					break;
				}
				remaindersSeen.Add(newRemainder);
				remainders.Add(newRemainder);
				remainder = newRemainder;
			}
			return 0;
		}
	}
}
