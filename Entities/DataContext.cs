using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SE141048_VoQuocHuy_PE.Identity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) //ke thua = super
        {
            //Ung dung DI (Dependency Injection)

        }
        public DbSet<Department> Deparments { get; set; }
        public DbSet<Professor> Professors { get; set; }
    }
}
