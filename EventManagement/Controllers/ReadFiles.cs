using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace EventManagement.Controllers
{
    // Class created for reading files from given tha path (from gui)
    // Also class is shredding data type. Files are csv, sql, xml, json format.
    public class ReadFiles
    {

        public List<string> CsvFiles { get; set; }
        public List<string> JsonFiles { get; set; }
        public List<string> SqlFiles { get; set; }
        public List<string> XmlFiles { get; set; }

        public string Get()
        {
            DataTable table = new DataTable();
            string path = "";

            var query = @"SELECT id, path, type FROM public.input;";

            var cs = "Server=127.0.0.1;Port=5432;Host=localhost;Username=postgres;Password=D1996b18;Database=LogDB";
            var con = new NpgsqlConnection(cs);

            var cmd = new NpgsqlCommand(query, con);
            using (var da = new NpgsqlDataAdapter(cmd))
            {
                da.Fill(table);
            }

            var op = table.Select();

            foreach (var kl in op)
            {
                var l = kl.ItemArray;
                int i = 0;
                foreach (var fg in l)
                {
                    if (i++ == 1)
                        //Console.WriteLine("-> "+fg);
                        path = fg.ToString();
                }
            }



            return path;
        }

        public ReadFiles()
        {
            string _path = Get();
            GetFilename(_path);
        }

        public void GetFilename(string path)
        {
            string[] f = Directory.GetFiles(path, "*.csv"); // using System.IO;
            CsvFiles = new List<string>(f);

            f = Directory.GetFiles(path, "*.json");
            JsonFiles = new List<string>(f);

            f = Directory.GetFiles(path, "*.sql");
            SqlFiles = new List<string>(f);

            f = Directory.GetFiles(path, "*.xml");
            XmlFiles = new List<string>(f);

        }

        public List<string[]> ReadCsvFiles(string path)
        {
            List<string[]> data = new List<string[]>();
            bool header = true;
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            for (string line = file.ReadLine(); line != null; line = file.ReadLine())
            {
                if (header)
                {
                    header = false;
                    continue;
                }
                data.Add(line.Split(','));
            }

            file.Close();
            return data;
        }


        // https://www.configapp.com/2018/07/10/using-jason-configuration-in-asp-net/
        public List<string[]> ReadJsonFiles(string path)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string total = "[ ";
            int i = 0;
            for (string line = file.ReadLine(); line != null; line = file.ReadLine())
            {
                if ((i++) < 2)
                    continue;
                else if (line == "]}")
                {
                    total += "]";
                    break;
                }
                total += line;
            }

            file.Close();

            List<string[]> data = new List<string[]>();

            try
            {
                var list = JsonConvert.DeserializeObject<List<JsonObj>>(total);


                foreach (JsonObj n in list)
                    data.Add(n.returned());

                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading json file is not successful.");
                return null;
            }
            return null;
        }


        public List<string[]> ReadSqlFiles(string path)
        {
            List<string[]> data = new List<string[]>();
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            for (string line = file.ReadLine(); line != null; line = file.ReadLine())
            {
                string temp = "";
                if ((line.CompareTo("INSERT INTO public.history (event_id,status,severity,category,\"source\",node,creation_date,node_id,subcategory,eti_type,eti_value,monitor_uuid,severity_id,information,occurance,update_date,alert_name) VALUES")) == 1)
                    continue;
                if (line.CompareTo(";") != 0)
                {

                    if (line.IndexOf("(") == 0)
                        temp = line.Substring(1, line.Length - 2);
                    else if (line.IndexOf(",(") == 0)
                        temp = line.Substring(2, line.Length - 3);

                    //Console.WriteLine(temp);

                    //string[] str = temp.Split(',');
                    //foreach (string op in str)
                    //    Console.WriteLine(op);
                    //Console.WriteLine("\n\n\n");

                    data.Add(temp.Split(','));
                }
            }
            file.Close();
            return data;
        }

        public List<string[]> ReadXmlFiles(string path)
        {
            List<string[]> data = new List<string[]>();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.DtdProcessing = DtdProcessing.Parse;

            using (var fileStream = File.OpenText(path))
            using (XmlReader reader = XmlReader.Create(fileStream, settings))
            {
                bool record = false;
                string junk = "";
                List<string> str = new List<string>();

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            junk = $"{reader.Name}";
                            if (junk.CompareTo("DATA_RECORD") == 0)
                                record = true;
                            //Console.WriteLine( $"Element: {reader.Name}:");
                            break;
                        case XmlNodeType.Text:
                            junk = $"{reader.Value}";

                            if (record)
                                str.Add(junk);
                            //Console.WriteLine($"Value: {reader.Value}");
                            break;
                        case XmlNodeType.EndElement:
                            //Console.WriteLine($"End Element: {reader.Name}\n\n");
                            junk = $"{reader.Name}";
                            if (junk.CompareTo("DATA_RECORD") == 0)
                            {
                                record = false;
                                data.Add(str.ToArray());
                                str.Clear();
                            }
                            break;
                        default:
                            //Console.WriteLine($"Unknown: {reader.NodeType}");
                            break;
                    }
                }// while 
            }
            return data;
        }
    }

}