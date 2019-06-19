using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
	public class Problem23 : EulerProblem
	{
		public const int maxToCheck = 28124;
		private IList<int> primes;

		public long Solve(string textfile = "")
		{
			primes = PrimesUtil.SetUpPrimes(maxToCheck);

			List<int> abundantNums = new List<int>(500);
			bool[] sumOfTwoAbundants = new bool[maxToCheck];

			FindAllAbundantNums(maxToCheck, abundantNums);

			foreach (int abundantNum in abundantNums)
			{
				for(int i =0; i < abundantNums.Count; ++i)
				{
					var sum = abundantNum + abundantNums[i];
					if (sum < maxToCheck)
						sumOfTwoAbundants[sum] = true;
				}
			}

			var totalNonAbundants = 0;
			for (int i = 1; i < maxToCheck; ++i)
			{
				if (!sumOfTwoAbundants[i])
				{
					totalNonAbundants += i;
				}
			}
			return totalNonAbundants;
		}

		private void FindAllAbundantNums(int max, List<int> abundantNums)
		{
			for(int i = 12; i <= max; ++i)
			{
				if (IsAbundant(i))
				{
					abundantNums.Add(i);
				}
			}
		}

		private bool IsAbundant(int intToCheck)
		{
			var factorization = GetPrimeFactorization(intToCheck);
			var sumOfDivisors = 1;
			foreach (var factor in factorization.Keys)
			{
				var sum = 0;
				for (int i = 0; i <= factorization[factor]; ++i)
				{
					sum += (int) Math.Round(Math.Pow(factor, i));
				}
				sumOfDivisors *= sum;
			}
			return sumOfDivisors > (2 * intToCheck);
		}

		private Dictionary<int, int> GetPrimeFactorization(int num)
		{
			var factorization = new Dictionary<int, int>();
			int primeIndex = 0;
			while (num != 1)
			{
				var possibleFactor = primes[primeIndex];
				if (num % possibleFactor == 0)
				{
					if (factorization.ContainsKey(possibleFactor))
					{
						factorization[possibleFactor] += 1;
					}
					else
					{
						factorization.Add(possibleFactor, 1);
					}
					num = num / possibleFactor;
				} else
				{
					++primeIndex;
				}
			}
			return factorization;
		}


	}
}
