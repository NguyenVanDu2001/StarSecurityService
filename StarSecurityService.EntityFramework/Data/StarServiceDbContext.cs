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
        public virtual DbSet<Bussiness> Bussinesss { get; set; }
        public virtual DbSet<GroupPermesstion> GroupPermesstions { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EfConfiguration(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        private static void EfConfiguration(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employyee>().ToTable("Employyee");
            //modelBuilder.Entity<Employyee>().HasKey(t => new { t.Id });
            //modelBuilder.Entity<Bussiness>().ToTable("Bussiness");
            //modelBuilder.Entity<Bussiness>().HasKey(t => new { t.Id });
            
            //modelBuilder.Entity<GroupUser>().ToTable("GroupUser");
            //modelBuilder.Entity<GroupUser>().HasKey(t => new { t.Id });
            //modelBuilder.Entity<Permission>().ToTable("Employyee");
            //modelBuilder.Entity<Permission>().HasKey(t => new { t.Id });
            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<User>().HasKey(t => new { t.Id });
        }
    }
}
