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
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<ClientEmployees> ClientEmployees { get; set; }
        public virtual DbSet<EmployeeAchievement> EmployeeAchievements { get; set; }
        public virtual DbSet<EmployeeServiceOffered> EmployeeServiceOffereds { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Branch> Branchs { get; set; }
        public virtual DbSet<ServiceOffer> ServiceOffers { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<ShareHolder> ShareHolders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            EfConfiguration(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        private static void EfConfiguration(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
