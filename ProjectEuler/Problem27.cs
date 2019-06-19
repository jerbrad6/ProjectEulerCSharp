using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	public class Problem27 : EulerProblem
	{
		private HashSet<int> primes;

		public long Solve(string textfile = "")
		{
			primes = PrimesUtil.SetUpPrimes(10000000).ToHashSet();

			var maxRun = 0;
			var maxRunA = 0;
			var maxRunB = 0;

			for (int b = 2; b < 1000; ++b)
			{
				if (primes.Contains(b))
				{
					for (int a = -999; a < 1000; ++a)
					{
						if (primes.Contains(1 + b + a))
						{
							var run = MaxPrimeRun(a, b) + 2;
							if (run > maxRun)
							{
								maxRun = run;
								maxRunA = a;
								maxRunB = b;
							}
						}
					}
				}
			}
			return maxRunA * maxRunB;
		}

		private int MaxPrimeRun(int a, int b)
		{
			int x = 2;
			bool isPrime;
			do
			{
				var num = x * x + x * a + b;
				isPrime = primes.Contains(num);
				++x;
			}
			while (isPrime);
			return x - 3;
		}
	}
}
