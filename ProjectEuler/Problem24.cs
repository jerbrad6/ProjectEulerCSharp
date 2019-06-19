using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
	public class Problem24 : EulerProblem
	{
		public int[] factorials = new int[11];
		public long Solve(string textfile = "")
		{
			int product = 1;
			factorials[0] = 1;
			for (int i = 1; i < factorials.Length; ++i)
			{
				product *= i;
				factorials[i] = product;
			}

			int[] countUsed = new int[11];
			var remainder = 999999;
			for (int i = 9; i >= 0; --i)
			{
				countUsed[i] = remainder / factorials[i];
				remainder = remainder % factorials[i];
			}
			var choices = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			string answer = "";
			for (int i = choices.Count - 1; i >= 0; --i)
			{
				answer += choices[countUsed[i]];
				choices.RemoveAt(countUsed[i]);
			}
			return long.Parse(answer);
		}
	}
}
