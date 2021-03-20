using Marketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Data
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options)
        {
            
        }
        //DbSets for tables in the database
        public DbSet<ModuleModel> Modules { get; set; }
        public DbSet<BidModel> Bids { get; set; }
        public DbSet<InstructorsModel> Instructors { get; set; }
        public DbSet<AdministratorModel> Administrators { get; set; }
    }
}