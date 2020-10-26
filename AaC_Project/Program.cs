using Algorithms_and_Computability_Project.Additional;
using Algorithms_and_Computability_Project.Solutions;
using System.Collections.Generic;

namespace Algorithms_and_Computability_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter number of partitions: ");
            var val = System.Console.ReadLine();
            int r = System.Convert.ToInt32(val);
            HashSet<int> set = FileOperations.ReadSetFromFile("../../Example/set.txt");

            System.Console.WriteLine();
            ExactSolution.Run(set, r);

            System.Console.WriteLine();
            HeuristicSolution.Run(set, r);
            System.Console.ReadKey();
        }
    }
}
