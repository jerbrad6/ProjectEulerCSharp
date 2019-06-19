using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{

    public class PrimesUtil
    {
		public static IList<int> SetUpPrimes(int maxNum)
		{
			List<int> primes = new List<int>(1000);
			for (int i = 2; i <= maxNum; ++i)
			{
				bool isPrime = true;
				foreach (int j in primes)
				{
					if (j > Math.Sqrt(i))
					{
						break;
					}
					if (i % j == 0)
					{
						isPrime = false;
						break;
					}
				}
				if (isPrime)
				{
					primes.Add(i);
				}
			}
		return primes;
		}

		public static Dictionary<int, int> GetPrimeFactorization(int num, int[] primes)
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
				}
				else
				{
					++primeIndex;
				}
			}
			return factorization;
		}

		public bool IsSameNumber(Dictionary<int,int> factorization1, Dictionary<int,int> factorization2)
		{
			return factorization1.Keys.OrderBy(x => x).SequenceEqual(factorization2.Keys.OrderBy(x => x)) &&
				factorization1.OrderBy(kvp => kvp.Key)
				.SequenceEqual(factorization2.OrderBy(kvp => kvp.Key));
		}
	}
}
