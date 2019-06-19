using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
	public class Problem28 : EulerProblem
	{
		public long Solve(string textfile = "")
		{
			var sum = 1;
			for (int i = 3; i < 1002; i+=2)
			{
				sum += 4 * i * i - (6 * i) + 6;
			}
			return sum;
		}
	}
}
