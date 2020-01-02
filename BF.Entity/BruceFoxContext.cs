using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BF.Entity
{
    public class BruceFoxContext : DbContext
    {
        public BruceFoxContext() : base("MyConnection")
        {

        }

        public DbSet<Champion> ChampionSet { get; set; }
        public DbSet<Skin> SkinSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here..
        }
    }
}
