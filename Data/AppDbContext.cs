using Microsoft.EntityFrameworkCore;
using pertemuan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
            // Kosong
        }
        public virtual DbSet<Blog> Tb_Blog { get; set; }    // Tb_Blog adalah nama tabelnya
        public virtual DbSet<Roles> Tb_Roles { get; set; }
        public virtual DbSet<User> Tb_User { get; set; }
    }

}
