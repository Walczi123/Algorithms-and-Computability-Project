using AaC_Project.Additional;
using Algorithms_and_Computability_Project.Additional;
using Algorithms_and_Computability_Project.Solutions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms_and_Computability_Project
{
    class Program
    {
        static void Main(string[] args)
        {              
            try
            {
                string x = "error";
                while(x != "1" && x!= "2"){
                    System.Console.WriteLine("Type '1' to read from file or '2' to provide data by yourself");
                    x = Console.ReadLine();
                }
                List<InputData> inputdata = null;
                if (x == "1")
                    inputdata = FileOperations.ReadSetFromFile("../../../Example/set.txt");
                else
                { 
                    inputdata = new List<InputData>();
                    x = "Yes";
                    while (x.ToLower() != "no")
                    {
                        if(x.ToLower() == "yes")    
                            ReadFromUser(inputdata);
                        System.Console.WriteLine("Do you want to add next data? [yes/no]");
                        x = Console.ReadLine();
                    }
                }
                var watch = new System.Diagnostics.Stopwatch();
                foreach (var data in inputdata)
                {
                    if(data.numberOfPartitions <= data.initialSet.Count)
                    {
                        watch.Reset();
                        System.Console.WriteLine("-------------");
                        watch.Start();
                        if (data.solution == Solution.ExactSolution)
                            ExactSolution.Run(data);
                        else
                            HeuristicSolution.Run(data);
                        watch.Stop();
                        Console.WriteLine($"time in milisecond: {watch.Elapsed.TotalMilliseconds}");
                        System.Console.WriteLine("-------------");
                    }
                    else
                    {
                        System.Console.WriteLine("Number of partitions has to be greater then cardinality of set.");
                    }
                }
            }
            catch(Exception e){
                System.Console.Write("Exception occured\n");
                System.Console.Write(e.ToString()+ "\n");
            }
            System.Console.Write("\nThe End");
            System.Console.ReadKey();
        }

        static void ReadFromUser(List<InputData> inputdata)
        {
            System.Console.WriteLine("Type number of partitions");
            string numberOfPartitions = Console.ReadLine();
            System.Console.WriteLine("Type 'o' to use optimal solution or 'h' to use heuristic solution");
            string solution = Console.ReadLine();
            System.Console.WriteLine("Type '1' to use first fitness function or '2' to use second fitness function");
            string function = Console.ReadLine();
            System.Console.WriteLine("Type elements of the set separated by commas");
            string set = Console.ReadLine();
            inputdata.Add(new InputData(numberOfPartitions, function, solution, set));
        }
    }
}
