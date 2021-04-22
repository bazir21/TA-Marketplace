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

        public IEnumerable<BidModel> GetPendingBids(string instructorId)
        {
            return db.Bids.Where(b => (b.InstructorBiddedId.Equals(instructorId) && (b.Accepted.Equals(BidStatus.Pending))))
            .ToList();
        }

        public IEnumerable<BidModel> GetAcceptedBids(string instructorId)
        {
            return db.Bids.Where(b => (b.InstructorBiddedId.Equals(instructorId) && (b.Accepted.Equals(BidStatus.Accepted))))
            .ToList();
        }

        public IEnumerable<BidModel> GetRejectedBids(string instructorId)
        {
            return db.Bids.Where(b => (b.InstructorBiddedId.Equals(instructorId) && (b.Accepted.Equals(BidStatus.Rejected))))
            .ToList();
        }
    }
}