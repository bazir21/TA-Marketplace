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
        public DbSet<Module> Modules { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}