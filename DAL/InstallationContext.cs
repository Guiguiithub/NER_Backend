using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InstallationContext : DbContext
    {
        public InstallationContext(DbContextOptions<InstallationContext> options) : base(options)
        {
        }
        public DbSet<Installation> Installations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=tcp:uas7db.database.windows.net,1433;Initial Catalog=NERDB;Persist Security Info=False;User ID=uas7admin;Password=77cTUwdJ4@Bd8h2qc!hS25L2LUq#4n;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            builder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            builder.EnableSensitiveDataLogging();
        }
    }
}
