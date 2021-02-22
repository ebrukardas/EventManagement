using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    /// <summary>
    /// Class prepared for whole application
    /// </summary>
    class Application
    {
        // all events taken from files in the given path
        HashSet<Mixed> eventSet;

        public Application()
        {
            eventSet = new HashSet<Mixed>();
        }

        // get start apriori algorithm with member eventSet
        public void app()
        {

            CreateEvents();
            //Console.WriteLine(eventSet.Count);
            // string getProp(int propIndex)
            Apriori ap = new Apriori();
            ap.apriori(eventSet);


        }

        // Read sql, xml, json ans csv file according to given path fron gui
        // and create event objects
        public void CreateEvents()
        {
            ReadFiles rf = new ReadFiles(); // rf.CsvFiles JsonFiles SqlFiles XmlFiles


            for (int i = 0; i < rf.CsvFiles.Count; ++i)
                Commons.UnionSets(eventSet, CreateEvents(rf.ReadCsvFiles(rf.CsvFiles[i]), "synthetic"));

            for (int i = 0; rf.JsonFiles != null && i < rf.JsonFiles.Count; ++i)
                Commons.UnionSets(eventSet, CreateEvents(rf.ReadJsonFiles(rf.JsonFiles[i]), "synthetic"));



            //for (int i = 0; rf.SqlFiles != null && i < rf.SqlFiles.Count; ++i)
            //    Commons.UnionSets(eventSet, CreateEvents(rf.ReadCsvFiles(rf.SqlFiles[i]), "synthetic"));


            //for (int i = 0; rf.XmlFiles != null && i < rf.XmlFiles.Count; ++i)
            //    Commons.UnionSets(eventSet, CreateEvents(rf.ReadCsvFiles(rf.XmlFiles[i]), "synthetic"));

        }

        // Read sql, xml, json ans csv file according to given path fron gui
        // and create event objects
        // Helper method
        public HashSet<Mixed> CreateEvents(List<string[]> list, string table)
        {
            if (list == null)
            {
                return null;
            }
            List<Mixed> eventList = new List<Mixed>();
            HashSet<Mixed> evtList = new HashSet<Mixed>();

            for (int eventNum = 0; eventNum < list.Count; ++eventNum)
                evtList.Add(new Mixed(list[eventNum]));
            //eventList.Add(new Event(table, list[eventNum]));

            return evtList;
        }

        // print all events just for checking
        public void printEvents()
        {
            foreach (var evt in eventSet)
            {
                Console.WriteLine(evt);
            }
        }
    }

}