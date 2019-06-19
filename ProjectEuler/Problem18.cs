using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	public class Problem18 : EulerProblem
	{
		public long Solve(string textfile)
		{
			var rows = new int[15][];
			var lines = File.ReadAllLines(textfile);
			var rowIndex = 0;
			foreach (var line in lines)
			{
				rows[rowIndex] = line.Split(new[] { ' ' }).Select(v => Int32.Parse(v)).ToArray();
				rowIndex++;
			}
			var remainingRowCount = rows.Length;
			while (remainingRowCount > 1)
			{
				var last = rows[remainingRowCount - 1];
				var secondLast = rows[remainingRowCount - 2];
				var index = 0;
				foreach(var value in secondLast)
				{
					secondLast[index] = secondLast[index] + Math.Max(last[index], last[index + 1]);
					index++;
				}
				last = null;
				remainingRowCount -= 1;
			}
			return rows[0].Single();
		}
	}
}
