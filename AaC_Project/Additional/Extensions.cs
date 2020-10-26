using System.Collections.Generic;
using System.Linq;

namespace Algorithms_and_Computability_Project

{
    static class Extensions
    {
        public static T RemoveFirst<T>(this ICollection<T> items)
        {
            T item = items.FirstOrDefault();
            if (item != null)
            {
                items.Remove(item);
            }
            return item;
        }

        public static List<HashSet<int>> Clone(this List<HashSet<int>> listToClone)
        {
            var list = new List<HashSet<int>>();
            foreach (var set in listToClone)
            {
                list.Add(set.Clone());
            }
            return list;
        }

        public static HashSet<int> Clone(this HashSet<int> setToClone)
        {
            var set = new HashSet<int>();
            foreach (var element in setToClone)
            {
                set.Add(element);
            }
            return set;
        }

        public static void Show(this List<List<HashSet<int>>> list)
        {
            foreach (var elements in list)
            {
                elements.Show();
            }
        }

        public static void Show(this List<HashSet<int>> list)
        {
            System.Console.Write("{");
            foreach (var elements in list)
            {
                System.Console.Write("{ ");
                foreach (var element in elements)
                    System.Console.Write(element + " ");
                System.Console.Write("} ");
            }
            System.Console.Write("} \n");
        }
    }
}
