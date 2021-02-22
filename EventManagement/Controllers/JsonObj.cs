using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    // Create JSON object for WEB API
    public class JsonObj
    {

        [JsonProperty("event_id")]
        public string eventid { get; set; }

        public string status { get; set; }

        public string severity { get; set; }

        public string category { get; set; }

        public string source { get; set; }
        public string node { get; set; }

        [JsonProperty("creation_date")]
        public DateTime creationdate { get; set; }

        [JsonProperty("node_id")]
        public string nodeid { get; set; }

        public string subcategory { get; set; }

        [JsonProperty("eti_type")]
        public string etitype { get; set; }

        [JsonProperty("eti_value")]
        public string etivalue { get; set; }

        [JsonProperty("monitor_uuid")]
        public string monitoruuid { get; set; }

        [JsonProperty("severity_id")]
        public int severityid { get; set; }
        public string information { get; set; }
        public int occurance { get; set; }

        [JsonProperty("update_date")]
        public DateTime updatedate { get; set; }

        [JsonProperty("alert_name")]
        public string alertname { get; set; }

        public string[] returned()
        {
            string[] temp = new string[17];

            temp[0] = eventid;
            temp[1] = status;
            temp[2] = severity;
            temp[3] = category;
            temp[4] = source;
            temp[5] = node;
            temp[6] = creationdate.ToString();
            temp[7] = nodeid;
            temp[8] = subcategory;
            temp[9] = etitype;
            temp[10] = etivalue;
            temp[11] = monitoruuid;
            temp[12] = severityid.ToString();
            temp[13] = information;
            temp[14] = occurance.ToString();
            temp[15] = updatedate.ToString();
            temp[16] = alertname;



            return temp;
        }

        public override string ToString()
        {

            return eventid + ", " + status + ", " + severity + ", " + category + ", " + source + ", " +
                node + ", " + creationdate + ", " + nodeid + ", " + subcategory + ", " + etitype + ", " +
                etivalue + ", " + monitoruuid + ", " + severityid + ", " + information + ", " + occurance + ", " +
                updatedate + ", " + alertname;
        }
    }

}