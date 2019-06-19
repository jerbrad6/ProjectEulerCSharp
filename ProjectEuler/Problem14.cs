using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
	public class Problem14 : EulerProblem
	{
		public long Solve(string textfile = "")
		{
			long maxNum = 0;
			short maxCount = 0;
			short[] counts = new short[100000000];

			for (long i = 1; i < 1000000; ++i)
			{
				var result = GetAndSetCountForNum(i, counts);
				if (result > maxCount)
				{
					maxNum = i;
					maxCount = result;
				}
			}
			Console.WriteLine($"Max Num:{maxNum} with count:{maxCount}");
			return (int)maxNum;

		}

		public short GetAndSetCountForNum(long num, short[] counts)
		{
			if (IsPowerOf2(num))
			{
				return (short)Math.Round(Math.Log(num, 2));
			}
			else if (num < counts.Length && counts[num] != 0)
			{
				return counts[num];
			}
			else
			{
				short result = 0;
				if (num % 2 == 0)
				{
					result = GetAndSetCountForNum(num / 2, counts);
				}
				else
				{
					result = GetAndSetCountForNum(num * 3 + 1, counts);
				}
				++result;
				if (num < counts.Length)
					counts[num] = result;
				return result;
			}
		}

		private bool IsPowerOf2(long num)
		{
			return num > 0 && (num & (num - 1)) == 0;
		}
	}
}
