using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Marketplace.Models;
using Marketplace.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Services
{
    public class InstructorService
    {
        private readonly MarketplaceContext db;
        public InstructorService(MarketplaceContext db)
        {
            this.db = db;
        }

        public IEnumerable<BidModel> GetPendingBids(string instructor)
        {
            return db.Bids.Where(b => (b.InstructorBiddedId.Equals(instructor) && (b.Accepted.Equals(0))))
            .ToList();
        }

        public IEnumerable<BidModel> GetAcceptedBids(string instructor)
        {
            return db.Bids.Where(b => (b.InstructorBiddedId.Equals(instructor) && (b.Accepted.Equals(1))))
            .ToList();
        }

        public IEnumerable<BidModel> GetRejectedBids(string instructor)
        {
            return db.Bids.Where(b => (b.InstructorBiddedId.Equals(instructor) && (b.Accepted.Equals(2))))
            .ToList();
        }
    }
}