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
        public string Id { get; set; }

        [Required(ErrorMessage = "Ini harus di isi")]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public bool Status { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
    }
    
    public class BlogDashBoard
    {
        public List<Blog> blog { get; set; }
        public List<User> user { get; set; }

        public BlogDashBoard()
        {
            blog = new List<Blog>();
            user = new List<User>();
        }
    }
}
