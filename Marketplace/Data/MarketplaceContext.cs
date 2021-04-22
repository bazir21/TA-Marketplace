using Marketplace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Marketplace.Data
{
    public class MarketplaceContext : IdentityDbContext<UserModel>
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options)
        {
            
        }
        public DbSet<ModuleModel> Modules { get; set; }
        public DbSet<BidModel> Bids { get; set; }
        public DbSet<InstructorModelList> Instructors { get; set; }
        public DbSet<InstructorModel> Instructor { get; set; }
        public DbSet<AdministratorModel> Administrators { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<ModuleModel>().ToTable("modules");
            // modelBuilder.Entity<BidModel>().ToTable("BidModel");
            // modelBuilder.Entity<InstructorModelList>().ToTable("InstructorModelList");
            // modelBuilder.Entity<InstructorModel>().HasKey(user => user.Id);
            // modelBuilder.Entity<InstructorModel>().ToTable("InstructorModel");
            // modelBuilder.Entity<AdministratorModel>().HasKey(admin => admin.Id);
            // modelBuilder.Entity<AdministratorModel>().ToTable("AdministratorModel");
            
        }
    }
}