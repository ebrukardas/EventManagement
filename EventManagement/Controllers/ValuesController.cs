using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("eventid");
            dt.Columns.Add("status");
            dt.Columns.Add("severity");
            dt.Columns.Add("category");
            dt.Columns.Add("sourcename");
            dt.Columns.Add("node");
            dt.Columns.Add("creationdate");
            dt.Columns.Add("nodeid");
            dt.Columns.Add("subcategory");
            dt.Columns.Add("etitype");
            dt.Columns.Add("etivalue");
            dt.Columns.Add("monitoruuid");
            dt.Columns.Add("severityid");
            dt.Columns.Add("information");
            dt.Columns.Add("occurance");
            dt.Columns.Add("updatedate");
            dt.Columns.Add("alertname");

            //dt.Rows.Add(1, "IT");
            dt.Rows.Add("lgeatdlogakwupvupzod", "Work In Progress", "Critical", "J2EE", "FortiSIEM", "Exchange", "2020-10-10 12:11:56.000", "ywuguaygmgsfrwddvgqn", "Exchange", "STATE CHANGED", "Error", "Monitor_28", 50, "information", 0, "2020-10-10 12:11:56.000", "AlertName-*");

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }


        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
