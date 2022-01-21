using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            // Kosong
        }

        public virtual DbSet<Blog> Tb_Blog { get; set; }    // Tb_Blog adalah nama tabelnya
        public virtual DbSet<Mobil> Tb_Mobil { get; set; }
        public virtual DbSet<Roles> Tb_Roles { get; set; }
        public virtual DbSet<User> Tb_User { get; set; }
    }
}
