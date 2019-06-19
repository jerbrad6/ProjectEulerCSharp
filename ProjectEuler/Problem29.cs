using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ProjectEuler
{
	public class Problem29 : EulerProblem
	{
		public long Solve(string textfile = "")
		{
			var nums = new HashSet<BigInteger>();
			for (int i = 2; i < 101; ++i)
			{
				for (int j = 2; j < 101; ++j)
				{
					var num = new BigInteger(i);
					nums.Add(BigInteger.Pow(num, j));
				}
			}

			return nums.Count;
		} 
	}
}
