using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
	public class Problem30 : EulerProblem
	{
		public long Solve(string textfile = "")
		{
			var sum = 0;
			for (int i=10; i < 1000000; ++i)
			{
				var productSum = 0;
				var j = i;
				while (j > 0)
				{
					productSum += (int) Math.Pow(j % 10, 5);
					j = j / 10;
				}
				if (productSum == i)
				{
					Console.WriteLine($"Found Num: {i}");
					sum += i;
				}
			}
			return sum;
		}
	}
}
