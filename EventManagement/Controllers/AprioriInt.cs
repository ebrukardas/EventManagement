using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    class AprioriInt
    {
        class CandidateSet
        {
            public CandidateSet(HashSet<int> _item, int _supportCount)
            {
                items = _item;
                supportCount = _supportCount;
            }
            public HashSet<int> items { get; set; }
            public int supportCount { get; set; }

            public void print()
            {
                Console.Write("{ ");
                foreach (int kk in items)
                {
                    Console.Write(kk + " ");
                }
                Console.WriteLine("} SC:" + supportCount);

            }
        }

        List<HashSet<int>> mySetList;
        int MSC = 2;
        List<HashSet<int>> elements;
        List<CandidateSet> myCandidateSets;



        public void /**/ apriori()
        {
            mySetList = getSet();
            elements = createSet(); // { {1},{2},{5},{4},{3} }
            myCandidateSets = new List<CandidateSet>();

            foreach (var i in elements)
                myCandidateSets.Add(new CandidateSet(i, CalcSupportCount(i)));

            int K = 2;
            List<HashSet<int>> setKTemp = new List<HashSet<int>>(generateKSubsets(elements, elements, K));

            for (; K < elements.Count; ++K)
            {
                setKTemp = new List<HashSet<int>>(generateKSubsets(setKTemp, elements, K));
                foreach (var i in setKTemp)
                    myCandidateSets.Add(new CandidateSet(i, CalcSupportCount(i)));
            }

            for (int i = 0; i < myCandidateSets.Count; ++i)
                if (myCandidateSets[i].supportCount < MSC)
                    myCandidateSets.RemoveAt(i--);


            for (int i = 0; i < myCandidateSets.Count; ++i)
            {
                for (int j = i + 1; j < myCandidateSets.Count; ++j)
                {
                    if (myCandidateSets[i].items.IsSubsetOf(myCandidateSets[j].items))
                    {

                        //myCandidateSets[j].print();
                        //myCandidateSets[i].print();
                        //Console.WriteLine(myCandidateSets[j].supportCount + "/" + myCandidateSets[i].supportCount);
                        double d = (myCandidateSets[j].supportCount / 1.0) / (myCandidateSets[i].supportCount / 1.0);
                        if (d >= 0.5)
                            Console.WriteLine("STRONG");
                        Console.WriteLine("\n");
                    }
                }
            }

            Console.WriteLine("\n\n");



            for (int i = myCandidateSets.Count - 1; i >= 0; --i)
                myCandidateSets[i].print();





            //subsetTest();



        }


        public int CalcSupportCount(HashSet<int> _set)
        {
            int sc = 0;
            for (int i = 0; i < mySetList.Count; ++i)
                if (_set.IsSubsetOf(mySetList[i]))
                    ++sc;
            return sc;
        }

        /**
         * Returns Sets with K elements
         * setList  = Set list with K-1 elements
         * setList2 = Set list with 1 elements
         **/
        public List<HashSet<int>> generateKSubsets(List<HashSet<int>> setList, List<HashSet<int>> setList2, int K)
        {
            List<HashSet<int>> returned = new List<HashSet<int>>();

            for (int i = 0; i < setList.Count; ++i)
            {
                for (int j = 0; j < setList2.Count; ++j)
                {
                    HashSet<int> temp = new HashSet<int>(setList[i]);
                    temp.UnionWith(setList2[j]);
                    if (temp.Count == K && !(Contains(returned, temp)))
                        returned.Add(new HashSet<int>(temp));
                }
            }
            return returned;
        }

        public bool Contains(List<HashSet<int>> list, HashSet<int> temp)
        {
            foreach (HashSet<int> x1 in list)
                if (x1.IsSubsetOf(temp))
                    return true;
            return false;
        }

        public List<HashSet<int>> createSet()
        {


            List<HashSet<int>> m1 = new List<HashSet<int>>();
            HashSet<int> totalSet = new HashSet<int>();

            // all items added once in totalSet
            foreach (HashSet<int> t1 in mySetList)
                totalSet.UnionWith(t1);

            foreach (int t in totalSet)
            {
                List<int> tm = new List<int>();
                tm.Add(t);
                m1.Add(new HashSet<int>(tm));
            }

            return m1;
        }



        // 'vunujhvtxıwowpvglgmq', 'Work In Progress', 'Normal', 'Application', 'PRTG', 'IBMDB2', 
        // '10.10.2020 09:12:06', 'hlaıwhszpkryvdgızeol', 'IBMDB2', 'SYSTEM OVERLOADED', 'Error', 'Monitor_0', 
        // '10', 'information', '0', '10.10.2020 09:12:06', 'AlertName-*'












        public void subsetTest()
        {
            List<HashSet<int>> setList = createSet(); // { {1},{2},{5},{4},{3} }
            int K = 2;
            List<HashSet<int>> r = new List<HashSet<int>>(generateKSubsets(setList, setList, K));

            for (; K < setList.Count; ++K)
            {
                r = new List<HashSet<int>>(generateKSubsets(r, setList, K));
                Console.WriteLine("K=" + K);
                print(r);
                Console.WriteLine("\n----------------------------------------");
            }

        }

        public void print(List<int> h)
        {
            Console.Write("{ ");
            foreach (int kk in h)
            {
                Console.Write(kk + " ");
            }
            Console.WriteLine("}");
        }

        public void print(HashSet<int> h)
        {
            Console.Write("{ ");
            foreach (int kk in h)
            {
                Console.Write(kk + " ");
            }
            Console.WriteLine("}");
        }

        public void print(List<HashSet<int>> m1)
        {
            foreach (HashSet<int> h in m1)
            {
                Console.Write("{ ");
                foreach (int kk in h)
                {
                    Console.Write(kk + " ");
                }
                Console.WriteLine("}");
            }
        }

        public void print(Dictionary<HashSet<int>, int> dict)
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

        public List<HashSet<int>> getSet()
        {

            List<HashSet<int>> returned = new List<HashSet<int>>();
            int[] t1 = { 1, 2, 5 }; int[] t2 = { 2, 4 }; int[] t3 = { 2, 3 };
            int[] t4 = { 1, 2, 4 }; int[] t5 = { 1, 3 }; int[] t6 = { 2, 3 };
            int[] t7 = { 1, 3 }; int[] t8 = { 1, 2, 3, 5 }; int[] t9 = { 1, 2, 3 };

            List<List<int>> op = new List<List<int>>();
            op.Add(new List<int>(t1)); op.Add(new List<int>(t2)); op.Add(new List<int>(t3));
            op.Add(new List<int>(t4)); op.Add(new List<int>(t5)); op.Add(new List<int>(t6));
            op.Add(new List<int>(t7)); op.Add(new List<int>(t8)); op.Add(new List<int>(t9));

            for (int i = 0; i < 9; ++i)
                returned.Add(new HashSet<int>(op[i]));

            return returned;
        }

        /*
        // Function to compute the value 
        // of Binomial Coefficient C(n, k) 
        public int binomialCoeff(int n, int k)
        {
            int[,] C = new int[n + 1, k + 1];
            int i, j;

            // Calculate value of Binomial Coefficient 
            // in bottom up manner 
            for (i = 0; i <= n; i++)
            {
                for (j = 0; j <= Math.Min(i, k); j++)
                {

                    // Base Cases 
                    if (j == 0 || j == i)
                        C[i, j] = 1;

                    // Calculate value using previously 
                    // stored values 
                    else
                        C[i, j] = C[i - 1, j - 1] + C[i - 1, j];
                }
            }

            return C[n, k];
        }
        */


    }

}