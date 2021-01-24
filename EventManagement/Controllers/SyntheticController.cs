using System.Web.Http;

//using WebAPI.Models; // Adding "Models" folder
using System.Data;
using Npgsql;
using System.Net.Http;
using System.Net;
using System;
using EventManagement.Models;

namespace EventManagement.Controllers
{
    public class SyntheticController : ApiController
    {

        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            var query = @"SELECT eventid, status, severity, category, sourcename, node, creationdate, nodeid, subcategory, etitype, etivalue, monitoruuid, severityid, information, occurance, updatedate, alertname  FROM public.synthetic;";
            // var query = @"";

            var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
            var con = new NpgsqlConnection(cs);

            var cmd = new NpgsqlCommand(query, con);
            using (var da = new NpgsqlDataAdapter(cmd))
            {
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }



        public string Post(Synthetic evt)
        {
            try
            {
                DataTable table = new DataTable();

                var query = @"INSERT INTO public.synthetic VALUES('" 
                            + evt.EventID       + @"', '"   + evt.Status        + @"', '" 
                            + evt.Severity      + @"', '"   + evt.Category      + @"', '" 
                            + evt.SourceName    + @"', '"   + evt.Node          + @"', '" 
                            + evt.CreationDate  + @"', '"   + evt.NodeID        + @"', '" 
                            + evt.Subcategory   + @"', '"   + evt.EtiType       + @"', '" 
                            + evt.EtiValue      + @"', '"   + evt.MonitorUuid   + @"', '" 
                            + evt.SeverityID    + @"', '"   + evt.Information   + @"', '" 
                            + evt.Occurance     + @"', '"   + evt.UpdateDate    + @"', '" 
                            + evt.AlertName     + @"' );";

                var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
                        var con = new NpgsqlConnection(cs);

                var cmd = new NpgsqlCommand(query, con);
                using (var da = new NpgsqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Add";
            }
        }
        
        public string Put(Synthetic evt)
        {
            try
            {
                DataTable table = new DataTable();


                var query = @"UPDATE public.synthetic 
                            SET status = '"
                            + evt.Status        + @"', severity ='"      + evt.Severity        + @"' , category ='"      
                            + evt.Category      + @"', sourcename ='"    + evt.SourceName      + @"' , node ='"         
                            + evt.Node          + @"', creationdate ='"  + evt.CreationDate    + @"' , nodeid ='"        
                            + evt.NodeID        + @"', subcategory ='"   + evt.Subcategory     + @"' , etitype ='"       
                            + evt.EtiType       + @"', etivalue ='"      + evt.EtiValue        + @"' , monitoruuid ='"   
                            + evt.MonitorUuid   + @"', severityid ='"    + evt.SeverityID      + @"' , information ='"
                            + evt.Information   + @"', occurance ='"     + evt.Occurance       + @"' , updatedate ='"     
                            + evt.UpdateDate    + @"', alertname ='"     + evt.AlertName     
                            + @"' WHERE eventid ='"  + evt.EventID          + @"';";


                var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
                var con = new NpgsqlConnection(cs);

                var cmd = new NpgsqlCommand(query, con);
                using (var da = new NpgsqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception)
            {
                return "Failed to Update";
            }
        }

        public string Delete(string id)
        {
            try
            {
                DataTable table = new DataTable();

                var query = @"DELETE FROM public.synthetic WHERE eventid = '" + id + @"';";

                var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
                var con = new NpgsqlConnection(cs);

                var cmd = new NpgsqlCommand(query, con);
                using (var da = new NpgsqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }
        
    }
}
