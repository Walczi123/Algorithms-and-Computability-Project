using System;
using System.Collections.Generic;
using System.Linq;

namespace AaC_Project.Additional
{
    public class InputData
    {
        public int numberOfPartitions;
        public FitnessFunction fitnessFuntion;
        public Solution solution;
        public List<int> initialSet;

        public InputData(string numberOfPartitions, string fitnessFuntion, string solution, string initialSet)
        {
            this.numberOfPartitions = Int32.Parse(numberOfPartitions);  

            if (fitnessFuntion == "2")
                this.fitnessFuntion = FitnessFunction.SecondFitnessFunction;
            else
                this.fitnessFuntion = FitnessFunction.FirstFitnessFunction;

            if (solution == "o")
                this.solution = Solution.ExactSolution;
            else
                this.solution = Solution.HeuristicSolution;

            var weighes = initialSet.Split(',');
            if (weighes.Length == 1)
            {
                var cardinality = Int32.Parse(weighes.First());
                this.initialSet = new List<int>();
                Random rnd = new Random();
                for (int i = 0; i < cardinality; i++)
                    this.initialSet.Add(rnd.Next(1,cardinality*2));
            }
            else
            {
                this.initialSet = weighes.Select(w => Int32.Parse(w)).ToList();
            }         
        }
    }

    public enum FitnessFunction
    {
        FirstFitnessFunction,
        SecondFitnessFunction
    }

    public enum Solution
    {
        ExactSolution,
        HeuristicSolution
    }
}
