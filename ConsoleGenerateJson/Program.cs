using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Kodepos.GenerateJson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CreateJson().Wait();
                CreateJsonExt().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (Debugger.IsAttached)
                {
                    Console.WriteLine("Press Enter key to exit.");
                    Console.ReadLine();
                }
            }
        }

        static async Task CreateJsonExt()
        {
            Console.WriteLine("Querying. Please wait...");
            string filename = "kodepos.extended.json";
            string s = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=datif;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var lst1 = new List<Prov>();
            var lst2 = new List<Kabu>();
            var lst3 = new List<Keca>();
            var lst4 = new List<Desa>();

            using (var conn = new SqlConnection(s))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dt1";
                    await conn.OpenAsync();
                    SqlDataReader r;

                    using (r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                            lst1.Add(new Prov() { Id = r["id"].ToString(), Nm = r["nm"].ToString() });
                    }

                    cmd.CommandText = "select * from dt2";
                    using (r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                            lst2.Add(new Kabu() { Id = r["id"].ToString(), Nm = r["nm"].ToString(), Type = r["type"].ToString() });
                    }

                    cmd.CommandText = "select * from dt3";
                    using (r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                            lst3.Add(new Keca() { Id = r["id"].ToString(), Nm = r["nm"].ToString() });
                    }

                    cmd.CommandText = "select * from dt4";
                    using (r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                            lst4.Add(new Desa() { Id = r["id"].ToString(), Nm = r["nm"].ToString(), Zip = r["zip"].ToString() });
                    }
                }
            }

            Console.WriteLine("Prov: " + lst1.Count);
            Console.WriteLine("Kabu: " + lst2.Count);
            Console.WriteLine("Keca: " + lst3.Count);
            Console.WriteLine("Desa: " + lst4.Count);
            Console.WriteLine("Creating JSON (extended). Please wait...");

            JObject o1 = JObject.Parse("{}");
            foreach (var l in lst1)
            {
                o1[l.Nm] = JObject.Parse(@"{}");
                o1[l.Nm]["ID"] = l.Id;
                var kabu = lst2.Where(x => x.Id.Substring(0, 2) == l.Id).Select(y => y);

                o1[l.Nm]["Kabupaten/Kota"] = JObject.Parse(@"{}");
                JObject oKabu = o1[l.Nm]["Kabupaten/Kota"] as JObject;
                foreach (var l2 in kabu)
                {
                    string sKabu = l2.Nm + ", " + l2.Type;
                    //string sKabu = l2.Nm;
                    oKabu[sKabu] = JObject.Parse(@"{}");
                    oKabu[sKabu]["ID"] = l2.Id;
                    oKabu[sKabu]["Type"] = l2.Type;

                    var keca = lst3.Where(x => x.Id.Substring(0, 5) == l2.Id).Select(y => y);

                    oKabu[sKabu]["Kecamatan"] = JObject.Parse(@"{}");
                    JObject oKeca = oKabu[sKabu]["Kecamatan"] as JObject;
                    foreach (var l3 in keca)
                    {
                        oKeca[l3.Nm] = JObject.Parse(@"{}");
                        oKeca[l3.Nm]["ID"] = l3.Id;
                        var desa = lst4.Where(x => x.Id.Substring(0, 8) == l3.Id).Select(y => y);

                        oKeca[l3.Nm]["Kelurahan/Desa"] = JObject.Parse(@"{}");
                        JObject oDesa = oKeca[l3.Nm]["Kelurahan/Desa"] as JObject;
                        foreach (var l4 in desa)
                        {
                            //oDesa[l4.Nm] = l4.Zip;
                            oDesa[l4.Nm] = JObject.Parse(@"{}");
                            oDesa[l4.Nm]["ID"] = l4.Id;
                            oDesa[l4.Nm]["Kode Pos"] = l4.Zip;
                        }
                        lst4.RemoveAll(x => x.Id.Substring(0, 8) == l3.Id);
                    }
                    lst3.RemoveAll(x => x.Id.Substring(0, 5) == l2.Id);
                }
                lst2.RemoveAll(x => x.Id.Substring(0, 2) == l.Id);
            }
            string sResult = JsonConvert.SerializeObject(o1);
            File.WriteAllText(Path.Combine(Path.GetFullPath("."), filename), sResult);
            Console.WriteLine("Done.");
        }


        static async Task CreateJson()
        {
            Console.WriteLine("Querying. Please wait...");
            string filename = "kodepos.simple.json";
            string s = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=datif;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            var lst1 = new List<Prov>();
            var lst2 = new List<Kabu>();
            var lst3 = new List<Keca>();
            var lst4 = new List<Desa>();

            using (var conn = new SqlConnection(s))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dt1";
                    await conn.OpenAsync();

                    SqlDataReader r;
                    using (r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                            lst1.Add(new Prov() { Id = r["id"].ToString(), Nm = r["nm"].ToString() });
                    }


                    cmd.CommandText = "select * from dt2";
                    using (r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                            lst2.Add(new Kabu() { Id = r["id"].ToString(), Nm = r["nm"].ToString(), Type = r["type"].ToString() });
                    }

                    cmd.CommandText = "select * from dt3";
                    using (r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                            lst3.Add(new Keca() { Id = r["id"].ToString(), Nm = r["nm"].ToString() });
                    }

                    cmd.CommandText = "select * from dt4";
                    using (r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                            lst4.Add(new Desa() { Id = r["id"].ToString(), Nm = r["nm"].ToString(), Zip = r["zip"].ToString() });
                    }

                }
            }

            Console.WriteLine("Prov: " + lst1.Count);
            Console.WriteLine("Kabu: " + lst2.Count);
            Console.WriteLine("Keca: " + lst3.Count);
            Console.WriteLine("Desa: " + lst4.Count);
            Console.WriteLine("Creating JSON (simple). Please wait...");

            JObject o1 = JObject.Parse("{}");
            foreach (var l in lst1)
            {
                o1[l.Nm] = JObject.Parse(@"{}");

                var kabu = lst2.Where(x => x.Id.Substring(0, 2) == l.Id).Select(y => y);
                //Console.WriteLine(l.Nm + " children: " + kabu.Count());

                foreach (var l2 in kabu)
                {
                    string sKabu = l2.Nm + ", " + l2.Type;
                    o1[l.Nm][sKabu] = JObject.Parse(@"{}");
                    var keca = lst3.Where(x => x.Id.Substring(0, 5) == l2.Id).Select(y => y);
                    //Console.WriteLine("----" + l2.Nm + " children: " + keca.Count());

                    foreach (var l3 in keca)
                    {
                        o1[l.Nm][sKabu][l3.Nm] = JObject.Parse(@"{}");
                        var desa = lst4.Where(x => x.Id.Substring(0, 8) == l3.Id).Select(y => y);
                        //Console.WriteLine("    ----" + l3.Nm + " children: " + desa.Count());
                        foreach (var l4 in desa)
                        {
                            o1[l.Nm][sKabu][l3.Nm][l4.Nm] = l4.Zip;
                        }
                        lst4.RemoveAll(x => x.Id.Substring(0, 8) == l3.Id);
                    }
                    lst3.RemoveAll(x => x.Id.Substring(0, 5) == l2.Id);
                }
                lst2.RemoveAll(x => x.Id.Substring(0, 2) == l.Id);
            }
            string sResult = JsonConvert.SerializeObject(o1);
            File.WriteAllText(Path.Combine(Path.GetFullPath("."), filename), sResult);
            Console.WriteLine("Done.");
        }

        static async Task<IDictionary<string, string>> GetData(string tblNm)
        {
            string s = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=datif;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var conn = new SqlConnection(s);
            var cmd = new SqlCommand("select * from " + tblNm, conn);
            await conn.OpenAsync();
            var r = await cmd.ExecuteReaderAsync();
            var dct = new Dictionary<string, string>();

            while (await r.ReadAsync())
                dct.Add(r[0].ToString(), r[1].ToString());

            Console.WriteLine("OK: " + dct.Count);
            r.Close();
            conn.Close();

            cmd.Dispose();
            conn.Dispose();
            return dct;
        }

    }


}
