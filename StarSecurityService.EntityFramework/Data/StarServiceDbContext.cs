using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.EntityFramework.Data
{
    public class StarServiceDbContext : DbContext
    {
        public StarServiceDbContext () : base("StarContext")
        {
        }
        public virtual DbSet<Employyee> Employyees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
