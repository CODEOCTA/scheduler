using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EmailScheduler.Model;

namespace EmailScheduler.DataContext
{
    class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-VHUC55M;Initial Catalog=fooddelivery;Integrated Security=True");
        }

        public   DbSet<Tbl_Admin> tbl_admin { get; set; }
    }
}
