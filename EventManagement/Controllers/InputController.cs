using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using WebAPI.Models; // Adding "Models" folder
using System.Data;
using Npgsql;
using EventManagement.Models;

namespace EventManagement.Controllers
{
    public class InputController : ApiController
    {
        DataTable exm;

        public DataTable getInput()
        {
            return exm;
        }

        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            var query = @"SELECT id, path, type FROM public.input;";

            var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
            var con = new NpgsqlConnection(cs);

            var cmd = new NpgsqlCommand(query, con);
            using (var da = new NpgsqlDataAdapter(cmd))
            {
                da.Fill(table);
            }
            exm = new DataTable();
            exm = table;

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }



        public string Post(Input evt)
        {
            System.Threading.Thread.Sleep(5000);

            try
            {
                DataTable table = new DataTable();

                var query = @"INSERT INTO public.input VALUES('"
                            + evt.path + @"', '"
                            + evt.type 
                            + @"' );";
                //Console.WriteLine(query);

                var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
                var con = new NpgsqlConnection(cs);

                var cmd = new NpgsqlCommand(query, con);
                using (var da = new NpgsqlDataAdapter(cmd))
                {
                    da.Fill(table);
                }


                return "Input taken";
            }
            catch (Exception)
            {
                return "Failed to Add";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();

                var query = @"DELETE FROM public.input WHERE id = " + id + @";";

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
