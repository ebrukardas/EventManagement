using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventManagement.Controllers
{
    public class ShowFilesController : ApiController
    {
        public HttpResponseMessage Get()
        {


            Application a = new Application();
            a.app();
            DataTable table = new DataTable();

            var query = @"SELECT support FROM public.relate; ";

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
                int i = 0;
                foreach (var fg in l)
                {
                    res.Add(int.Parse(fg.ToString()));
                }
            }

            System.Threading.Thread.Sleep(30000);


            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}
