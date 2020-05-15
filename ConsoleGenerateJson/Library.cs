using System;
using System.Collections.Generic;
using System.Text;

namespace Kodepos.GenerateJson
{
    interface IDatif
    {
        string Id { get; set; }
        string Nm { get; set; }

    }

    public class Prov : IDatif
    {
        public Prov() { }
        public Prov(string id, string name)
        {
            Id = id;
            Nm = name;
        }
        public string Id { get; set; }
        public string Nm { get; set; }
    }
    public class Kabu : Prov, IDatif
    {
        public Kabu() { }
        public Kabu(string id, string name, string type)
        {
            Id = id;
            Nm = name;
            Type = type;
        }
        public string Type { get; set; }
    }
    public class Keca : IDatif
    {
        public Keca() { }
        public Keca(string id, string name)
        {
            Id = id;
            Nm = name;
        }
        public string Id { get; set; }
        public string Nm { get; set; }
    }
    public class Desa : Prov, IDatif
    {
        public Desa() { }

        public Desa(string id, string name, string zip)
        {
            Id = id;
            Nm = name;
            Zip = zip;
        }
        public string Zip { get; set; }
    }

}
