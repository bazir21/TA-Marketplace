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

        public BidModel getBidById(int Id)
        {
            return this.db.Bids.Find(Id);
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

        public void EditBid(BidModel bid)
        {
            BidModel oldBid = this.db.Bids.Find(bid.Id + 1);
            this.db.Bids.Update(oldBid);
            oldBid.HoursBid = bid.HoursBid;
            this.db.SaveChanges();
        }

        public void DeleteBid(int bidId)
        {
            BidModel bidToRemove = this.db.Bids.Find(bidId + 1);
            this.db.Bids.Remove(bidToRemove);
            this.db.SaveChanges();
        }
    
    }
}