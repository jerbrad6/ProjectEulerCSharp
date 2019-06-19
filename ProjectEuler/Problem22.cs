using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	public class Problem22 : EulerProblem
	{
		public long Solve(string textfile = "")
		{
			var names = new List<string>(5000);
			var lines = File.ReadAllLines(textfile);
			foreach (var line in lines)
			{
				names = line.Split(new[] { ',', '\"'}, StringSplitOptions.RemoveEmptyEntries).ToList();
			}
			names.Sort();

			long totalCount = 0;
			var index = 1;
			foreach (var name in names)
			{
				totalCount += (long)index * GetValueForName(name);
				++index;
			}
			return totalCount;
		}

		private long GetValueForName(string name)
		{
			var total = 0;
			foreach (char character in name.ToCharArray())
			{
				total += character - 'A' + 1;
			}
			return total;
		}
	}
}
