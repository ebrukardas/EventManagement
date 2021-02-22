using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    class Program_Yedek
    {





        //*************************************************************************************************
        //*************************************************************************************************
        //*************************************************************************************************
        //*************************************************************************************************

        public static void tests()
        {
            //testReadFile();
            //testAprioriInt();


            //Apriori a = new Apriori();
            //a.apriori();

            /*
            string[] t9 = { "fnwuarowxbtpoqomfhhj", "Work In Progress", "Minor", "Database", "AlienVault", "WAS",
                "10.10.2020 09:11:15", "vkmxrxczhetxwcstfyzv", "WAS", "CPU USAGE", "High", "Monitor_63",
                "30", "information", "0", "10.10.2020 09:11:15", "AlertName-*" };
            
            Mixed m = new Mixed(t9);
            Console.WriteLine("*" + m + "*");
            */
        }


        public static List<Event> CreateEvents(List<string[]> list, string table)
        {
            if (list == null)
            {
                return null;
            }
            List<Event> eventList = new List<Event>();

            for (int eventNum = 0; eventNum < list.Count; ++eventNum)
                eventList.Add(new Event(table, list[eventNum]));

            return eventList;
        }

        public static void testAprioriInt()
        {
            /*
            List<HashSet<int>> returned = new List<HashSet<int>>();
            int[] t1 = { 1, 2, 5 }; 
            int[] t2 = { 2, 4 }; 
            int[] t3 = { 2, 3 };
            int[] t4 = { 1, 2, 4 }; 
            int[] t5 = { 1, 3 }; 
            int[] t6 = { 2, 3 };
            int[] t7 = { 1, 3 }; 
            int[] t8 = { 1, 2, 3, 5 }; 
            int[] t9 = { 1, 2, 3 };

            List<List<int>> op = new List<List<int>>();
            op.Add(new List<int>(t1)); op.Add(new List<int>(t2)); op.Add(new List<int>(t3));
            op.Add(new List<int>(t4)); op.Add(new List<int>(t5)); op.Add(new List<int>(t6));
            op.Add(new List<int>(t7)); op.Add(new List<int>(t8)); op.Add(new List<int>(t9));

            for (int i = 0; i < 9; ++i)
                returned.Add(new HashSet<int>(op[i]));
            */

            AprioriInt a = new AprioriInt();
            a.apriori();

        }

        public static void testReadFile()
        {
            // read all files in the given path
            //string path = @"C:\Users\ebruk\Desktop\CSE496 Bitirme 2\Data\Data\Karışık";
            ReadFiles rf = new ReadFiles();

            //PrintAllFiles(rf);
            //PrintEventsAndCommands_CSV( rf.CsvFiles,   rf);
            PrintEventsAndCommands_JSON(rf.JsonFiles, rf);
            //PrintEventsAndCommands_SQL( rf.SqlFiles,   rf);
            //PrintEventsAndCommands_XML( rf.XmlFiles,   rf);
        }


        public static void PrintAllFiles(ReadFiles rf)
        {
            List<string> CsvFileNames = rf.CsvFiles;
            List<string> JsonFileNames = rf.JsonFiles;
            List<string> SqlFileNames = rf.SqlFiles;
            List<string> XmlFileNames = rf.XmlFiles;


            Console.WriteLine("CSV Files:");
            foreach (string i in CsvFileNames)
                Console.WriteLine(i);
            Console.WriteLine("\nJSON Files:");
            foreach (string i in JsonFileNames)
                Console.WriteLine(i);
            Console.WriteLine("\nSQL Files:");
            foreach (string i in SqlFileNames)
                Console.WriteLine(i);
            Console.WriteLine("\nXML Files:");
            foreach (string i in XmlFileNames)
                Console.WriteLine(i);
        }

        public static void PrintEventsAndCommands_CSV(List<string> CsvFileNames, ReadFiles rf)
        {

            for (int i = 0; i < CsvFileNames.Count; ++i)
            {
                Console.WriteLine(CsvFileNames.Count);
                List<Event> events = CreateEvents(rf.ReadCsvFiles(CsvFileNames[i]), "synthetic");

                // all CsvFileNames files are read & seperated by comma (',')
                Console.WriteLine(events[i].ToString() + "\n\n");
                Console.WriteLine(events[i].GetCommand() + "\n\n");
                Console.WriteLine(events[i].AddCommand() + "\n\n");
                Console.WriteLine(events[i].UpdateCommand() + "\n\n");
                Console.WriteLine(events[i].DeleteCommand("jıxojzjgoesayvlfvgca") + "\n\n");
            }
        }

        public static void PrintEventsAndCommands_JSON(List<string> JsonFileNames, ReadFiles rf)
        {
            Console.WriteLine("-----" + JsonFileNames[0]);
            if (JsonFileNames == null)
            {
                Console.WriteLine("Nothing to print.");
                return;
            }
            for (int i = 0; i < JsonFileNames.Count; ++i)
            {
                //Console.WriteLine(JsonFileNames.Count);
                List<Event> events = CreateEvents(rf.ReadJsonFiles(JsonFileNames[i]), "synthetic");
                int j = 0;
                if (events == null)
                {
                    continue;
                }
                for (j = 0; j < events.Count; ++j)
                {
                    // all CsvFileNames files are read & seperated by comma (',')
                    Console.WriteLine(events[j].ToString() + "\n");
                    //Console.WriteLine(events[j].GetCommand() + "\n\n");
                    //Console.WriteLine(events[j].AddCommand() + "\n\n");
                    //Console.WriteLine(events[j].UpdateCommand() + "\n\n----------------------------\n");
                    //Console.WriteLine(events[j].DeleteCommand("jıxojzjgoesayvlfvgca") + "\n\n");
                }
                Console.WriteLine(j);
            }
        }

        public static void PrintEventsAndCommands_SQL(List<string> SqlFileNames, ReadFiles rf)
        {

            for (int i = 0; i < SqlFileNames.Count; ++i)
            {
                Console.WriteLine(SqlFileNames.Count);
                List<Event> events = CreateEvents(rf.ReadSqlFiles(SqlFileNames[i]), "synthetic");
                int j = 0;
                for (j = 0; j < events.Count; ++j)
                {
                    // all CsvFileNames files are read & seperated by comma (',')
                    Console.WriteLine(events[j].ToString() + "\n");
                    //Console.WriteLine(events[j].GetCommand() + "\n\n");
                    //Console.WriteLine(events[j].AddCommand() + "\n\n");
                    Console.WriteLine(events[j].UpdateCommand() + "\n\n----------------------------\n");
                    //Console.WriteLine(events[j].DeleteCommand("jıxojzjgoesayvlfvgca") + "\n\n");
                }
                Console.WriteLine(j);
            }
        }

        public static void PrintEventsAndCommands_XML(List<string> XmlFileNames, ReadFiles rf)
        {

            for (int i = 0; i < XmlFileNames.Count; ++i)
            {
                Console.WriteLine(XmlFileNames.Count);
                List<Event> events = CreateEvents(rf.ReadXmlFiles(XmlFileNames[i]), "synthetic");
                int j = 0;
                for (j = 0; j < events.Count; ++j)
                {
                    // all CsvFileNames files are read & seperated by comma (',')
                    Console.WriteLine(events[j].ToString() + "\n");
                    //Console.WriteLine(events[j].GetCommand() + "\n\n");
                    //Console.WriteLine(events[j].AddCommand() + "\n\n");
                    Console.WriteLine(events[j].UpdateCommand() + "\n\n----------------------------\n");
                    //Console.WriteLine(events[j].DeleteCommand("jıxojzjgoesayvlfvgca") + "\n\n");
                }
                Console.WriteLine(j);
            }
        }

        /*
        static public int lengthLoop(int[] arr) {
            // test
                // # means "number of" in case you don't know
                //int[] array1 = new int[] { 8,4,6,3,5,8,7,2,1};
                //Console.WriteLine("#loop={0}\", lengthLoop(array1));
            // #loop
            int loopCounter = 0;
            // visited ik
            int[] visited = new int[arr.Length];

            //  init visited:  0 => not visited, 1 => visited
            for (int k=0; k<arr.Length; ++k){
                visited[k] = 0; 
            }
    
            // loop for whole array which means O(n)
            for (int i=0; i<arr.Length ; ++i ) {

                // if ith element is visited, continue the loop
                if (visited[i] == 1){
                    continue;
                }
                int i1 = 0, firstVisited = 0, n = arr[i];

                // checks if *ith* element's value (n) is in the limits of the array (arr[0]=8, i=0)
                if ( n>= arr.Length) {
                    Console.WriteLine("Error Length");
                    return -1;
                }

                // nth element's value is in the limits of the array (arr[8]=1, i1=1)
                i1 = arr[n];
                if (arr[i1] >= arr.Length){
                    Console.WriteLine("Error Length");
                    return -1;
                }

                // first visited element (firstVisited = 1)
                firstVisited = i1;

                // loop for (kth length loop)  ik = 4
                // i1, i2, ..., ik must be in the limits of the array
                // as update: i1 will be ik (i1=4) and 
                // ik wil bee i1th element (ik=5) for i=0 second inner loop
                for (int ik = arr[i1]; i1 < arr.Length && ik < arr.Length; i1 = ik, ik = arr[i1]){

                    // i1=1 ik=4 arr[1]==4 
                    // i1th element and ik is equal
                    if (arr[i1] != ik){
                        break;
                    }

                    // print visited element & mark
                    Console.Write("{0} \", i1);
                    visited[i1] = 1;
                    
                    // if it is the first element, break the loop 
                    // 1 was visited arr[8]=1 so break the loop (last loop)
                    if (arr[i1] == firstVisited){
                        ++loopCounter;
                        break;
                    }
                }
                Console.WriteLine("\n");
            }
            return loopCounter;
        }
        */
    }

}