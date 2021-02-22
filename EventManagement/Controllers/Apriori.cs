using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace EventManagement.Controllers
{
    class Apriori
    {
        HashSet<Mixed> mySetList;
        List<HashSet<Mixed>> elements;
        List<CandidateSet> myCandidateSets;
        int MSC = 2;

        // candidate sets with support count
        class CandidateSet
        {
            public CandidateSet(HashSet<Mixed> _item, int _supportCount)
            {
                items = _item;
                supportCount = _supportCount;
            }
            public HashSet<Mixed> items { get; set; }
            public int supportCount { get; set; }

            public void print()
            {
                Console.Write("{ ");
                foreach (Mixed kk in items)
                {
                    Console.Write(kk.getProp(1) + ", ");
                }
                Console.WriteLine("} SC:" + supportCount);
            }
        }

        // If "new login" occurs 5 times, the threat is real IN SAME DAY.
        public int Rule1()
        {
            int freq = 0;
            string prop = "";
            int i = 0;
            DateTime dt = new DateTime();
            foreach (var k in mySetList)
            {
                if (k.getProp(9) == "NEW LOGIN")
                {
                    if (i == 0)
                    {
                        prop = k.getProp(5);
                        ++i;
                        dt = DateTime.Parse(k.getProp(6));
                        continue;
                    }
                    if (prop == k.getProp(5))
                    {
                        DateTime enteredDate = DateTime.Parse(k.getProp(6));
                        if (enteredDate.Hour == dt.Hour)
                            ++freq;
                    }
                    else
                    {
                        prop = k.getProp(5);
                    }
                }
            }
            return freq;
        }

        // appliaction is busy
        public int Rule2()
        {
            int freq = 0;
            string prop = "";
            int i = 0;
            foreach (var k in mySetList)
            {
                if (k.getProp(9) == "HALTED" || k.getProp(9) == "LINK DOWN")
                {
                    if (i == 0)
                    {
                        prop = k.getProp(3);
                        ++i;
                        continue;
                    }
                    if (prop == "Application")
                    {
                        ++freq;
                    }
                    else
                    {
                        prop = k.getProp(3);
                    }
                }
            }
            return freq;
        }

        // sunucu meşguliyeti
        public int Rule3()
        {
            int freq = 0;
            string prop = "";
            int i = 0;
            foreach (var k in mySetList)
            {
                if (k.getProp(9) == "HALTED" || k.getProp(9) == "LINK DOWN")
                {
                    if (i == 0)
                    {
                        prop = k.getProp(3);
                        ++i;
                        continue;
                    }
                    if (prop == "Web Service" || prop == "Database")
                    {
                        ++freq;
                    }
                    else
                    {
                        prop = k.getProp(3);
                    }
                }
            }
            Console.WriteLine(freq);
            return freq;

        }

        // sürekli yeniden başlatma
        public int Rule4()
        {
            int freq = 0;
            string prop = "";
            int i = 0;
            foreach (var k in mySetList)
            {
                if (k.getProp(9) == "SYSTEM OVERLOADED")
                {
                    if (i == 0)
                    {
                        prop = k.getProp(3);
                        ++i;
                        continue;
                    }
                    if (prop == "Web Service" || prop == "Database")
                    {
                        ++freq;
                    }
                    else
                    {
                        prop = k.getProp(3);
                    }
                }
            }
            return freq;
        }

        // hardware error
        public int Rule5()
        {
            int freq = 0;
            string prop = "";
            int i = 0;
            foreach (var k in mySetList)
            {
                if (k.getProp(9) == "CPU USAGE" || k.getProp(9) == "POWER ERROR" ||
                    k.getProp(9) == "TEMPATURE" || k.getProp(9) == "LOW DISK")
                {
                    if (i == 0)
                    {
                        prop = k.getProp(3);
                        ++i;
                        continue;
                    }
                    if (prop == "Web Service" || prop == "Database")
                    {
                        ++freq;
                    }
                    else
                    {
                        prop = k.getProp(3);
                    }
                }
            }
            //Console.WriteLine(freq);
            return freq;
        }

        // 2: warning ve uyarının sıklığı
        public int Rule6()
        {
            int freq = 0;
            string prop = "";
            int i = 0;
            foreach (var k in mySetList)
            {
                if (k.getProp(2) == "Warning" || k.getProp(2) == "Critical")
                {
                    if (i == 0)
                    {
                        prop = k.getProp(10);
                        ++i;
                        continue;
                    }
                    if (prop == "Error")
                    {
                        ++freq;
                    }
                    else
                    {
                        prop = k.getProp(10);
                    }
                }
            }
            //Console.WriteLine(freq); 
            return freq;

        }

        public void WriteAnalysisToDb(int freq)
        {
            System.Threading.Thread.Sleep(3000); try
            {
                DataTable table = new DataTable();

                var query = @"INSERT INTO public.relate VALUES('"
                            + freq + @"' );";

                var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
                var con = new NpgsqlConnection(cs);

                var cmd = new NpgsqlCommand(query, con);
                using (var da = new NpgsqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
            }
            catch (Exception)
            {
            }
        }

        public void ClearRelate()
        {
            System.Threading.Thread.Sleep(3000); try
            {
                DataTable table = new DataTable();

                var query = @"DELETE FROM public.relate ;";

                var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
                var con = new NpgsqlConnection(cs);

                var cmd = new NpgsqlCommand(query, con);
                using (var da = new NpgsqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }
            }
            catch (Exception)
            {
            }
        }

        // apriori algorithm
        public void apriori(HashSet<Mixed> set_)
        {
            ClearRelate();
            WriteAnalysisToDb(apriori(set_, 1));
            WriteAnalysisToDb(apriori(set_, 2));
            WriteAnalysisToDb(apriori(set_, 3));
            WriteAnalysisToDb(apriori(set_, 4));
            WriteAnalysisToDb(apriori(set_, 5));
            WriteAnalysisToDb(apriori(set_, 6));
        }

        // apriori helper algorithm
        public int apriori(HashSet<Mixed> set_, int ruleNumber)
        {

            //subsetTest();
            elements = new List<HashSet<Mixed>>();
            myCandidateSets = new List<CandidateSet>();
            mySetList = set_;
            // fill the "elements" list
            createSet();
            int freq = 0;

            switch (ruleNumber)
            {
                case 1:
                    freq = Rule1();
                    break;
                case 2:
                    freq = Rule2();
                    break;
                case 3:
                    freq = Rule3();
                    break;
                case 4:
                    freq = Rule4();
                    break;
                case 5:
                    freq = Rule5();
                    break;
                case 6:
                    freq = Rule6();
                    break;

            }
            return freq;

        }

        // create a whole set to generating candidate sets
        public void createSet()
        {
            foreach (Mixed m in mySetList)
            {
                // every element (Event) is unique
                HashSet<Mixed> p = new HashSet<Mixed>();
                p.Add(m);
                elements.Add(new HashSet<Mixed>(p));
            }
        }

        // calculate support count for the _set with given property
        public int CalcSupportCount(HashSet<Mixed> _set, int prop)
        {
            int sc = 0;
            //Commons.print(_set);
            foreach (HashSet<Mixed> m in elements)
            {
                //Commons.print(m);
                if (isSubset(m, _set, prop))
                    ++sc;
            }
            return sc;
        }



        // Is set2 subset of the set1 check
        // prop is used for comparison based on
        public bool isSubset(HashSet<Mixed> set1, HashSet<Mixed> set2, int prop)
        {
            foreach (var elem in set2)
            {
                bool tempFlag = false;
                foreach (var elem2 in set1)
                {
                    // if the property of the element in set1 is the same as 
                    // in the set2
                    if (elem.getProp(prop).Equals(elem2.getProp(prop)))
                    {
                        tempFlag = true;
                        break;
                    }
                }
                if (tempFlag == false)
                    return false;
            }
            return true;
        }



        // generate K number subset for the algorithm

        public List<HashSet<Mixed>> generateKSubset(List<HashSet<Mixed>> setList, List<HashSet<Mixed>> setList2, int K)
        {
            List<HashSet<Mixed>> returned = new List<HashSet<Mixed>>();

            for (int i = 0; i < setList.Count; ++i)
            {
                for (int j = 0; j < setList2.Count; ++j)
                {
                    // union with subset for candidate set
                    HashSet<Mixed> temp = new HashSet<Mixed>(setList[i]);
                    temp.UnionWith(setList2[j]);
                    // if the number of the set is less than K and 
                    // the element is not in the set, then add the set to return
                    if (temp.Count == K && !(Commons.Contains(returned, temp)))
                    {
                        returned.Add(new HashSet<Mixed>(temp));
                    }
                }
            }
            return returned;
        }

        // get results of the analysis from the database
        public List<int> GetResult()
        {
            DataTable table = new DataTable();
            // connect database for output of the analysis
            var query = @"SELECT support FROM public.relate;";
            var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
            var con = new NpgsqlConnection(cs);
            var cmd = new NpgsqlCommand(query, con);
            using (var da = new NpgsqlDataAdapter(cmd))
            {
                da.Fill(table);
            }

            List<int> res = new List<int>();
            var op = table.Select();
            foreach (var kl in op)
            {
                var l = kl.ItemArray;
                foreach (var fg in l)
                {
                    res.Add(int.Parse(fg.ToString()));
                }
            }
            return res;
        }

        // ///////////////////////////////////////////////////////////////////////////////////////////////
        // ///////////////////////////////////////////////////////////////////////////////////////////////
        // ///////////////////////////////////////////////////////////////////////////////////////////////

        // Getting set examples for tests
        public HashSet<Mixed> getSet()
        {
            HashSet<Mixed> returned = new HashSet<Mixed>();
            string[] t1 = { "vunujhvtxıwowpvglgmq", "Work In Progress", "Normal", "Application", "PRTG", "IBMDB2",
                            "10.10.2020 09:12:06", "hlaıwhszpkryvdgızeol", "IBMDB2", "SYSTEM OVERLOADED", "Error", "Monitor_0",
                            "10", "information", "0", "10.10.2020 09:12:06", "AlertName-*" };

            string[] t2 = { "jıxojzjgoesayvlfvgca", "Open", "Warning", "Database", "Solarwinds", "WAS",
                "10.10.2020 09:11:10", "efczkxoveyrcjgnzuzxı", "WAS", "SYSTEM OVERLOADED", "High", "Monitor_55",
                "20", "information", "0", "10.10.2020 09:11:10", "AlertName-*" };
            string[] t3 = { "qcyojymbcrydhvqdkrzı", "Open", "Critical", "J2EE", "LogRhythm", "Oracle",
                "10.10.2020 09:11:12", "jvısqdknngovvreonhkl", "Oracle", "LOW DISK", "Good", "Monitor_65",
                "50", "information", "0", "10.10.2020 09:11:12", "AlertName-*" };
            string[] t4 = { "vugfzdgxrksgrfawlgrp", "New", "Normal", "Application", "SiteScope", "Apache",
                "10.10.2020 09:11:12", "bvwashxmcavwemıfhgbb", "Apache", "CPU USAGE", "Warning", "Monitor_93", "10",
                "information", "0", "10.10.2020 09:11:12", "AlertName-*" };
            string[] t5 = {"jxsaynqnrvfbxoqsıfzj", "Open", "Major", "Web Service", "Insight", "MongoDB",
                "10.10.2020 09:11:13", "sunsyqpvhzgıyjhvoıxy", "MongoDB", "CPU USAGE", "Low", "Monitor_25",
                "40", "information", "0", "10.10.2020 09:11:13", "AlertName-*" };
            string[] t6 = { "zsıgftkjvffjwluorlmt", "Open", "Critical", "Database", "Solarwinds", "MongoDB",
                "10.10.2020 09:11:14", "fttugtwsondazxmyoıpc", "MongoDB", "NEW LOGIN", "Warning", "Monitor_90",
                "50", "information", "0", "10.10.2020 09:11:14", "AlertName-*" };
            string[] t7 = { "aazllewodwycgkdpoked", "New", "Normal", "Application", "Insight", "Firebase",
                "10.10.2020 09:11:14", "dxmmıpvuacokpzgeskbq", "Firebase", "NETWORK INTERFACE ERROR", "High", "Monitor_60",
                "10", "information", "0", "10.10.2020 09:11:14", "AlertName-*"  };
            string[] t8 = { "klbrnkjtcyaphkkkdsık", "New", "Normal", "J2EE", "PRTG", "NGINX",
                "10.10.2020 09:11:15", "pngfoarbrakjtmrmıgvu", "NGINX", "LOW DISK", "Warning", "Monitor_94",
                "10", "information", "0", "10.10.2020 09:11:15", "AlertName-*"  };


            /*
            string[] t9 = { "fnwuarowxbtpoqomfhhj", "Work In Progress", "Minor", "Database", "AlienVault", "WAS",
                "10.10.2020 09:11:15", "vkmxrxczhetxwcstfyzv", "WAS", "CPU USAGE", "High", "Monitor_63",
                "30", "information", "0", "10.10.2020 09:11:15", "AlertName-*" };
            */
            string[] t10 = { "vunujhvtxıwowpvglgmq", "Work In Progress", "Normal", "Application", "PRTG", "IBMDB2",
                            "10.10.2020 09:12:06", "hlaıwhszpkryvdgızeol", "IBMDB2", "SYSTEM OVERLOADED", "Error", "Monitor_0",
                            "10", "information", "0", "10.10.2020 09:12:06", "AlertName-*" };


            //List<Mixed> op = new List<Mixed>();
            returned.Add(new Mixed(t1)); returned.Add(new Mixed(t2)); returned.Add(new Mixed(t3));
            returned.Add(new Mixed(t4)); returned.Add(new Mixed(t5)); returned.Add(new Mixed(t6));
            returned.Add(new Mixed(t7)); returned.Add(new Mixed(t8)); //returned.Add(new Mixed(t9));
            returned.Add(new Mixed(t10));

            //for (int i = 0; i < 9; ++i)
            //    returned.Add(new HashSet<string>(op[i]));

            return returned;
        }
    }
}
