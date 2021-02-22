using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    // Class is created for common methods as static
    static class Commons
    {
        // union two sets 
        public static HashSet<Mixed> UnionSets(HashSet<Mixed> set1, HashSet<Mixed> set2)
        {
            foreach (Mixed evt2 in set2)
            {
                if (!Contains(set1, evt2))
                {
                    set1.Add(evt2);
                }
            }
            return set1;
        }

        // check if the event is in the set
        public static bool Contains(HashSet<Mixed> set1, Event evnt)
        {
            foreach (Mixed evt in set1)
                if (evt.Equals(evnt))
                    return true;

            return false;
        }

        // check if the named "temp" set is in the set list in the "list"
        public static bool Contains(List<HashSet<Mixed>> list, HashSet<Mixed> temp)
        {
            foreach (HashSet<Mixed> x1 in list)
                if (x1.IsSubsetOf(temp))
                    return true;
            return false;
        }

        // PRINT ALL LIST/SET/DICTIONARY to use/check in the Apriori

        public static void print(List<int> h)
        {
            Console.Write("{ ");
            foreach (int kk in h)
            {
                Console.Write(kk + " ");
            }
            Console.WriteLine("}");
        }

        public static void print(HashSet<Mixed> h)
        {
            int i = 1;
            foreach (Mixed kk in h)
                //Console.WriteLine((i++) + ": " + kk + "\n");
                Console.WriteLine(kk.getProp(0));
            Console.WriteLine("\n");
        }

        public static void print(List<HashSet<Mixed>> m1)
        {
            foreach (HashSet<Mixed> h in m1)
            {
                Console.WriteLine("{ ");
                foreach (Mixed kk in h)
                {
                    Console.WriteLine(kk);
                }
                Console.WriteLine("}");
            }
        }

        public static void print(Dictionary<HashSet<int>, int> dict)
        {
            foreach (var pair in dict)
            {
                HashSet<int> key = pair.Key;
                Console.Write("{");
                foreach (int k in key)
                {
                    Console.Write(k + " ");
                }
                Console.WriteLine("} : " + pair.Value.ToString());
            }
        }


    }

}