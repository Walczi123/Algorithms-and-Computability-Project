using System.Collections.Generic;
using System.Linq;

namespace Algorithms_and_Computability_Project.Solutions

{
    static class ExactSolution
    {
        public static void Run(HashSet<int> set, int r)
        {
            if (set.Count >= r)
            {
                var allSubsets = AllSubsets(set.Clone(), r);
                int minWeight = int.MaxValue;
                List<HashSet<int>> bestSolution = null;
                foreach (var list in allSubsets)
                {
                    var weight = list.ComputeFitnessFunctions();
                    if (weight < minWeight)
                    {
                        minWeight = weight;
                        bestSolution = list;
                    }
                }
                System.Console.WriteLine("The best exact solution is");
                bestSolution.Show();
            }
            else
            {
                System.Console.WriteLine("Number of partitions has to be greater then cardinality of set.");
            }

        }
        public static List<List<HashSet<int>>> AllSubsets(HashSet<int> set, int r)
        {
            if (r == 1)
                return new List<List<HashSet<int>>>() { new List<HashSet<int>>() { set } };
            if (r == set.Count())
            {
                var result = new List<HashSet<int>>();
                foreach (var element in set)
                {
                    result.Add(new HashSet<int>() { element });
                }
                return new List<List<HashSet<int>>>() { result };
            }
            var a = set.RemoveFirst();
            var A = AllSubsets(set.Clone(), r);
            var resultSubsets = new List<List<HashSet<int>>>();
            foreach (var result in A)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    var clonedSet = result.Clone();
                    clonedSet.ElementAt(i).Add(a);
                    resultSubsets.Add(clonedSet);
                }
            }
            var B = AllSubsets(set.Clone(), r - 1);
            foreach (var element in B)
            {
                var clonedSet = element.Clone();
                clonedSet.Add(new HashSet<int>() { a });
                resultSubsets.Add(clonedSet);
            }
            return resultSubsets;
        }
        public static int ComputeFitnessFunctions(this List<HashSet<int>> list)
        {
            var sums = list.Select(set => set.Sum());
            return sums.Max() - sums.Min();
        }
    }
}
