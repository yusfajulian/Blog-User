using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Models
{
    public class Blog
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Contengt { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

    }
}
