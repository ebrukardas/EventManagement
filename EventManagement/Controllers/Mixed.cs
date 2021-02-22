using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    // Mixed event object that extends Events class
    public class Mixed : Event
    {
        public Mixed()
        {

        }
        public Mixed(string[] list) : base("mixed", list)
        {

            /*
            EventID = list[0];
            Status = list[1];
            Severity = list[2];
            Category = list[3];
            Source = list[4];
            Node = list[5];
            CreationDate = list[6];
            NodeID = list[7];
            Subcategory = list[8];
            EtiType = list[9];
            EtiValue = list[10];
            MonitorUuid = list[11];
            SeverityID = list[12];
            Information = list[13];
            Occurance = list[14];
            UpdateDate = list[15];
            AlertName = list[16];
            /*
            IP = list[0];
            DNS = list[0];
            MacAddress = list[0];
            */
        }
        /*
        override public string ToString()
        {
            string str = "";
            str = "{" +
            //EventID +
            //
            ", " +
            Status + ", " +
            Severity + ", " +
            Category + ", " +
            Source + ", " +
            Node + ", " +
            CreationDate + ", " +
            NodeID + ", " +
            Subcategory + ", " +
            EtiType + ", " +
            EtiValue + ", " +
            MonitorUuid + ", " +
            SeverityID + ", " +
            Information + ", " +
            Occurance + ", " +
            UpdateDate + ", " +
            AlertName + 
            //
            "}";
            ///*
            IP = list[0];
            DNS = list[0];
            MacAddress = list[0];
            //
            return str;
        }
        */
        /*
        public string EventID { get; set; }
        public string Status { get; set; }
        public string Severity { get; set; }
        public string Category { get; set; }
        public string Source { get; set; }
        public string Node { get; set; }
        public string CreationDate { get; set; }
        public string NodeID { get; set; }
        public string Subcategory { get; set; }
        public string EtiType { get; set; }
        public string EtiValue { get; set; }
        public string MonitorUuid { get; set; }
        public string SeverityID { get; set; }
        public string Information { get; set; }
        public string Occurance { get; set; }
        public string UpdateDate { get; set; }
        public string AlertName { get; set; }
        public string IP { get; set; }
        public string DNS { get; set; }
        public string MacAddress { get; set; }
        */
    }

}