using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Models
{
    public class Blog
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("JUDUL")]
        public string Title { get; set; }

        [Required]
        [DisplayName("ISI")]
        public string Contengt { get; set; }

        [Required]
        [DisplayName("AUTHORL")]
        public string Author { get; set; }

        [Required]
        [DisplayName("TGL PEMBUATAN")]
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

    }
}
