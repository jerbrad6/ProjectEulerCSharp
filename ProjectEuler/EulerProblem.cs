using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public interface EulerProblem
    {
		long Solve(string textfile = "");
    }
}
