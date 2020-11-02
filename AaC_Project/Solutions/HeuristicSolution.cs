using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms_and_Computability_Project.Solutions

{
    public static class HeuristicSolution
    {
        public static void Run(List<int> set, int r)
        {
            if (set.Count >= r)
            {
                List<int> sortedSet = set.OrderByDescending(value => value).ToList();
                List<List<int>> result = new List<List<int>>();
                for (int i = 0; i < r; i++)
                    result.Add(new List<int>());
                foreach (var s in sortedSet)
                {
                    result.MinimalSubset().Add(s);
                }
                Console.WriteLine("The best heuristic solution is");
                result.Show();
                System.Console.WriteLine("Fitness function: " + result.ComputeFitnessFunctions());
            }
            else
            {
                Console.WriteLine("Number of partitions has to be greater then cardinality of set.");
            }
        }

        public static List<int> MinimalSubset(this List<List<int>> list)
        {
            var min = list.Select(set => set.Sum()).Min();
            return list.Where(set => set.Sum() == min).First();
        }
    }
}
