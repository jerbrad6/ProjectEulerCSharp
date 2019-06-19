using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
			EulerProblem problem = new Problem29();
            Console.WriteLine(problem.Solve(@"C:\Users\jeremy.bradford\personal_workspace\ProjectEuler\ProjectEuler\Inputs\Problem22Input.txt"));
			Console.WriteLine("Press any key to exit");
			Console.ReadLine();
        }
    }
}
