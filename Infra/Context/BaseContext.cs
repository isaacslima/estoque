using Infra.Config;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infra.Context
{
    public class BaseContext : DbContext
    {
        public IDbConnection Connection { get; set; }

        public  BaseContext()
        {
            Connection = new SqliteConnection("Filename=Database.db");
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
