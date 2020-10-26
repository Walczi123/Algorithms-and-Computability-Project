using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms_and_Computability_Project.Solutions

{
    public static class HeuristicSolution
    {
        public static void Run(HashSet<int> set, int r)
        {
            if (set.Count >= r)
            {
                SortedSet<int> sortedSet = new SortedSet<int>(set) { };
                List<HashSet<int>> result = new List<HashSet<int>>();
                for (int i = 0; i < r; i++)
                    result.Add(new HashSet<int>());
                foreach (var s in sortedSet.Reverse())
                {
                    result.MinimalSubset().Add(s);
                }
                Console.WriteLine("The best heuristic solution is");
                result.Show();
            }
            else
            {
                Console.WriteLine("Number of partitions has to be greater then cardinality of set.");
            }
        }

        public static HashSet<int> MinimalSubset(this List<HashSet<int>> list)
        {
            var min = list.Select(set => set.Sum()).Min();
            return list.Where(set => set.Sum() == min).First();
        }
    }
}
