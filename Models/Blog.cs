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
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public bool Status { get; set; }
        public User User { get; set; }
    }
}
