using AaC_Project.Additional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms_and_Computability_Project.Solutions
{
    public static class HeuristicSolution
    {
        public static void Run(InputData data)
        {
            System.Console.WriteLine($"HeuristicSolution for r={data.numberOfPartitions} cardinality of set is equal {data.initialSet.Count} and for {data.fitnessFuntion}");
            List<int> sortedSet = data.initialSet.OrderByDescending(value => value).ToList();
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < data.numberOfPartitions; i++)
                result.Add(new List<int>());
            foreach (var s in sortedSet)
            {
                result.MinimalSubset().Add(s);
            }
            Console.WriteLine("The best heuristic solution is");
            //if(data.numberOfPartitions < 20)
            result.Show();
            if(data.fitnessFuntion == FitnessFunction.FirstFitnessFunction)
                System.Console.WriteLine("Fitness function: " + result.ComputeFirstFitnessFunctions());
            else
                System.Console.WriteLine("Fitness function: " + result.ComputeSecondFitnessFunctions());
        }

        public static List<int> MinimalSubset(this List<List<int>> list)
        {
            var min = list.Select(set => set.Sum()).Min();
            return list.Where(set => set.Sum() == min).First();
        }
    }
}
