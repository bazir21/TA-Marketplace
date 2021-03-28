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
    public class BidService
    {
        private readonly MarketplaceContext db;
        public BidService(MarketplaceContext db)
        {
            this.db = db;
        }

        public IEnumerable<BidModel> GetBids()
        {
            return  db.Bids.ToList();
        }

        public void CreateBid(BidModel bid)
        {
        
            this.db.Bids.Add(bid);
            this.db.SaveChanges();
        }

    }
}