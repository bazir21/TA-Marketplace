using Marketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Data
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options)
        {
            
        }
        public DbSet<ModuleModel> Modules { get; set; }
        public DbSet<BidModel> Bids { get; set; }
        public DbSet<InstructorModelList> Instructors { get; set; }
        public DbSet<AdministratorModel> Administrators { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleModel>().ToTable("modules");
            modelBuilder.Entity<BidModel>().ToTable("BidModel");
            modelBuilder.Entity<InstructorModelList>().ToTable("InstructorModelList");
            modelBuilder.Entity<AdministratorModel>().ToTable("AdministratorModel");
            modelBuilder.Entity<UserModel>().ToTable("UserModel");
        }
    }
}