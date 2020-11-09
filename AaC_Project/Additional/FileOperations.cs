using AaC_Project.Additional;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms_and_Computability_Project.Additional
{
    public static class FileOperations
    {
        public static List<InputData> ReadSetFromFile(string localization)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(localization);
                int usersNumber = lines.Count() / 4;
                List<InputData> result = new List<InputData>();
                for (int i = 0; i < usersNumber; i++)
                {
                    var numberOfPartitions = lines[i * 4];
                    var solition = lines[i * 4 + 1];
                    var fitnessFuntion = lines[i * 4 + 2];
                    var initialSet = lines[i * 4 + 3];
                    result.Add(new InputData(numberOfPartitions, fitnessFuntion, solition, initialSet));
                }
                return result;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
