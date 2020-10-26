using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms_and_Computability_Project.Additional
{
    public static class FileOperations
    {
        public static HashSet<int> ReadSetFromFile(string localization)
        {
            try
            {
                using (var sr = new StreamReader(localization))
                {
                    var words = sr.ReadToEnd().Split(',');
                    return new HashSet<int>(words.Select(w => Int32.Parse(w)));
                }
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
