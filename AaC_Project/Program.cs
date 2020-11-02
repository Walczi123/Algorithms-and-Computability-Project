using Algorithms_and_Computability_Project.Additional;
using Algorithms_and_Computability_Project.Solutions;
using System;
using System.Collections.Generic;

namespace Algorithms_and_Computability_Project
{
    class Program
    {
        static void Main(string[] args)
        {              
            try
            {
                System.Console.Write("Enter number of partitions: ");
                var val = System.Console.ReadLine();
                int r = System.Convert.ToInt32(val);
                List<int> set = FileOperations.ReadSetFromFile("../../../Example/set.txt");
                System.Console.Write("Initial elements: ");
                set.Show();
                System.Console.Write("Number of elements: " + set.Count + "\n");

                System.Console.WriteLine("\n---Exact Solution---");
                ExactSolution.Run(set, r);
                
                System.Console.WriteLine("\n---Heuristic Solution---");
                HeuristicSolution.Run(set, r);
            }
            catch(Exception e){
                System.Console.Write("Exception occured\n");
                System.Console.Write(e.ToString()+ "\n");
            }

            System.Console.Write("\nThe End");
            System.Console.ReadKey();
        }
    }
}
