using AaC_Project.Additional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms_and_Computability_Project.Solutions
{
    static class ExactSolution
    {
        public static void Run(InputData data)
        {
            System.Console.WriteLine($"ExactSolution for r={data.numberOfPartitions} cardinality of set is equal {data.initialSet.Count} and for {data.fitnessFuntion}");
            var allSubsets = AllSubsets(data.initialSet.Clone(), data.numberOfPartitions);         
            List<List<int>> bestSolution = null;
            if(data.fitnessFuntion == FitnessFunction.FirstFitnessFunction)
            {
                int minWeight = int.MaxValue;
                foreach (var list in allSubsets)
                {
                    var weight = list.ComputeFirstFitnessFunctions();
                    if (weight < minWeight)
                    {
                        minWeight = weight;
                        bestSolution = list;
                    }
                }
                System.Console.WriteLine("The best exact solution is");
                bestSolution.Show();
                System.Console.WriteLine("Fitness function rasult: " + minWeight);
            }
            else
            {
                double minWeight = Double.MaxValue;
                foreach (var list in allSubsets)
                {
                    var weight = list.ComputeSecondFitnessFunctions();
                    if (weight < minWeight)
                    {
                        minWeight = weight;
                        bestSolution = list;
                    }
                }
                System.Console.WriteLine("The best exact solution is");
                bestSolution.Show();
                System.Console.WriteLine("Fitness function: " + minWeight);
            }
        }

        public static List<List<List<int>>> AllSubsets(List<int> set, int r)
        {
            if (r == 1)
                return new List<List<List<int>>>() { new List<List<int>>() { set } };
            if (r == set.Count())
            {
                var result = new List<List<int>>();
                foreach (var element in set)
                {
                    result.Add(new List<int>() { element });
                }
                return new List<List<List<int>>>() { result };
            }
            var a = set.RemoveFirst();
            var A = AllSubsets(set.Clone(), r);
            var resultSubsets = new List<List<List<int>>>();
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
                clonedSet.Add(new List<int>() { a });
                resultSubsets.Add(clonedSet);
            }
            return resultSubsets;
        }
        public static int ComputeFirstFitnessFunctions(this List<List<int>> list)
        {
            var sums = list.Select(set => set.Sum()).ToList();
            return sums.Max() - sums.Min();
        }

        public static double ComputeSecondFitnessFunctions(this List<List<int>> list)
        {
            var sums = list.Select(set => set.Sum()).ToList();
            double result = 0;
            double average = (double)sums.Sum() / list.Count();
            foreach (var sum in sums)
                result += Math.Abs(sum - average);
            return result;
        }
    }
}
