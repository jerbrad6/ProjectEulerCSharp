using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler
{
	public class Problem25 : EulerProblem
	{
		public long Solve(string textfile = "")
		{
			var fibs = new List<BigInteger>(200);
			fibs.Add(BigInteger.One);
			fibs.Add(BigInteger.One);
			int index = 2;
			while (true)
			{
				var newFib = fibs[index - 1] + fibs[index - 2];
				if (newFib.ToString().Length >= 1000)
				{
					return index + 1;
				} else
				{
					fibs.Add(newFib);
				}
				index++;
			}

		}
	}
}
