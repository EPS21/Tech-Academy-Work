using MonsterDB.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MonsterDB.DAL
{
    public class MonsterContext : DbContext
    {
        public MonsterContext() : base("MonsterContext")
        {
        }

        public DbSet<Monster> Monsters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}