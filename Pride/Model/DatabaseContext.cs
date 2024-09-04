using Microsoft.EntityFrameworkCore;
using Pride.Models;
using Pride.Storedprocedure;
using Pride.StoredProcedure;

namespace Pride.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpAssignedRoleList>().HasNoKey().ToView(null);
            modelBuilder.Entity<SPAssignedRoleToUser>().HasNoKey().ToView(null);
        }


        public DbSet<Leads> TblLeads { get; set; }
        public DbSet<TblAssignRoleToUser> TblAssignRoleToUser { get; set; }
        public DbSet<MenuList> TblMenuList { get; set; }
        public DbSet<TblUser> TblUser { get; set; }
        public DbSet<Brokers> TblBrokers { get; set; }
        public DbSet<Insurance> TblInsurance { get; set; }
        public DbSet<FinanceCompany> TblFinanceCompany { get; set; }
        public DbSet<StateList> TblStates { get; set; }
        public DbSet<SpAssignedRoleList> SpAssignedRoleList { get; set; }
      public DbSet<Clients> TblClients { get; set; }
      public DbSet<SPAssignedRoleToUser> SPAssignedRoleToUser { get; set; }
      public DbSet<SpUserMenu> SpUserMenu { get; set; }

    }
}