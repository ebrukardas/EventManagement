using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Controllers
{
    // Synthetic event object that extends Events class

    public class Synthetic
    {
        public string EventID { get; set; }
        public string Status { get; set; }
        public string Severity { get; set; }
        public string Category { get; set; }
        public string SourceName { get; set; }
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
    }
}