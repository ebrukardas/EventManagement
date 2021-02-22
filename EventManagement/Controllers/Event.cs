using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    // BASIC Event class that used for Mixed and Synthetic
    // Class has database query, properties and ToString()
    public class Event
    {
        protected enum COLUMN_IND
        {
            EVENTID/*0*/, STATUS/*1*/, SEVERITY/*2*/,
            CATEGORY/*3*/, SOURCENAME/*4*/, NODE/*5*/,
            CREATIONDATE/*6*/, NODEID/*7*/, SUBCATEGORY/*8*/,
            ETITYPE/*9*/, ETIVALUE/*10*/, MONITORUUID/*11*/,
            SEVERITYID/*12*/, INFO/*13*/, OCCURANCE/*14*/,
            UPDATEDATE/*15*/, ALERTNAME/*16*/
            , IP/*17*/, DNS/*18*/, MACADDRESS/*19*/
        }
        protected int COLUMN_LEN;
        protected List<string> EVENT_VALUE = new List<string>();

        protected string tableName = "";
        protected string[] colName = { "eventid",        "status",       "severity",
                                       "category",       "sourcename",   "node",
                                       "creationdate",   "nodeid",       "subcategory",
                                       "etitype",        "etivalue",     "monitoruuid",
                                       "severityid",     "info",         "occurance",
                                       "updatedate",     "alertname",
                                       "ip",             "dns",          "macaddress"
                                     };
        public Event(string tableName, string[] e)
        {
            /*
            if (tableName == "synthetic")
                COLUMN_LEN = 17;
            else if (tableName == "mixed")
                COLUMN_LEN = 20;
            else
                throw new FormatException();
            */
            COLUMN_LEN = 17;
            this.tableName = tableName;
            EVENT_VALUE.InsertRange(0, e);
        }

        public Event() { }

        public string getEventId()
        {
            return EVENT_VALUE[0];
        }

        /*
         Get property of the Event with given index
         */
        public string getProp(int propIndex)
        {
            if (propIndex >= 0 && propIndex < EVENT_VALUE.Count)
                return EVENT_VALUE[propIndex];
            return "";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Event temp = (Event)obj;
            for (int i = 0; i < temp.COLUMN_LEN; ++i)
            {
                //Console.WriteLine(i + ".: " + EVENT_VALUE[i] + " == " + temp.EVENT_VALUE[i] + " ? ");
                if (EVENT_VALUE[i] != temp.EVENT_VALUE[i])
                    return false;
            }
            return true;
        }

        public string GetCommand()
        {
            string cmd = @"SELECT ";
            foreach (int column in Enum.GetValues(typeof(COLUMN_IND)))
            {
                cmd += colName[column];
                if (column != COLUMN_LEN - 1)
                    cmd += @", ";
                else
                    cmd += @"";
            }
            cmd += @" FROM public." + tableName + ";";
            return cmd;
        }
        public string UpdateCommand()
        {
            string cmd = @"UPDATE public." + tableName + " SET ";

            string temp = @"";
            foreach (int column in Enum.GetValues(typeof(COLUMN_IND)))
            {
                if (column == 0)
                    temp += @" WHERE eventid = '" + EVENT_VALUE[column] + @"';";
                else if (column != COLUMN_LEN - 1)
                    cmd += colName[column] + @" = '" + EVENT_VALUE[column] + @"', ";
                else
                    cmd += colName[column] + @" = '" + EVENT_VALUE[column] + @"'";
            }
            cmd += temp;

            return cmd;
        }

        public string AddCommand()
        {
            string cmd = @"INSERT INTO public." + tableName + " VALUES(";
            foreach (int column in Enum.GetValues(typeof(COLUMN_IND)))
            {
                cmd += @"'" + EVENT_VALUE[column];
                if (column != COLUMN_LEN - 1)
                    cmd += @"', ";
                else
                    cmd += @"'";
            }
            cmd += @");";
            return cmd;
        }

        public string DeleteCommand(string id)
        {
            string cmd = @"DELETE FROM public." + tableName
                + @" WHERE eventid ='" + EVENT_VALUE[(int)COLUMN_IND.EVENTID] + @"';";
            return cmd;
        }

        override public string ToString()
        {
            string total = "{";
            //foreach (int i in Enum.GetValues(typeof(COLUMN_IND)))
            for (int i = 0; i < 17; ++i)
            {
                if (i == 16)
                    total += EVENT_VALUE[i] + " ";
                else
                    total += EVENT_VALUE[i] + ", ";
            }
            return (total += "}");
        }
    }

}