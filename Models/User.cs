using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Models
{
    public class User
    {
        public int id { get; internal set; }
        public string NamaUser { get; internal set; }
        public string Jenis_kelamin { get; internal set; }
    }
}
