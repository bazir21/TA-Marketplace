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
    public class AdminService
    {
        private readonly MarketplaceContext db;
        public AdminService(MarketplaceContext db)
        {
            this.db = db;
        }

        public InstructorModel GetInstructorById(string Id)
        {
            return db.Instructor.Find(Id);
        }

        public ModuleModel GetModuleById(int Id)
        {
            return db.Modules.Find(Id);
        }

        public IEnumerable<ModuleModel> GetModulesWithBids()
        {
            /*
            IEnumerable<BidModel> bids= db.Bids.Where(b => (b.Accepted.Equals(0))).ToList();
            return db.Modules.Where(m => m.Id.Equals(bids.FirstOrDefault().Id)).ToList();*/
            return db.Modules.ToList();
        }

        public IEnumerable<InstructorModel> ViewInstructors()
        {
            return db.Instructor.ToList();
        }

        public IEnumerable<ModuleModel> ViewModules()
        {
            return db.Modules.ToList();
        }

        public IEnumerable<BidModel> GetActiveBids(ModuleModel module)
        {
            return db.Bids.Where(b => (b.Accepted.Equals(0)) && (b.ModuleModelId.Equals(module.Id))).ToList();
        }

        public void EditInstructor(InstructorModel instructor)
        {
            InstructorModel oldInstructor = this.db.Instructor.Find(instructor.Id);
            this.db.Instructor.Update(oldInstructor); 
            oldInstructor.Level = instructor.Level;    
            this.db.SaveChanges();
        }

        public void EditModule(ModuleModel module)
        {
            ModuleModel oldModule= this.db.Modules.Find(module.Id);
            this.db.Modules.Update(oldModule);
            oldModule.MaxHoursPerInstructor= module.MaxHoursPerInstructor;
            oldModule.MinHoursPerInstructor= module.MinHoursPerInstructor;
            oldModule.TotalHoursAvailable= module.TotalHoursAvailable;
    
            this.db.SaveChanges();
        }

        public IEnumerable<BidModel> GetInstructorsThatBid(int id)
        {
            return db.Bids.Where(b => (b.ModuleModelId.Equals(id)) && (b.Accepted.Equals(0))).ToList();
        }

        public Dictionary<int, string> GetAmountOfBids()
        {
            Dictionary<int, string> bidCount= new Dictionary<int, string>();
            IEnumerable<ModuleModel> modules= GetModulesWithBids();
            foreach(var module in modules)
            {
                bidCount.Add(module.Id, db.Bids.Where(b => (b.ModuleModelId.Equals(module.Id)) && (b.Accepted.Equals(0))).Count().ToString());
            }
            return bidCount;
        }

        

        public void AcceptBid(int id)
        {
            BidModel oldBid = this.db.Bids.Find(id);
            ModuleModel currentModule = GetModuleById(oldBid.ModuleModelId);
          
            this.db.Bids.Update(oldBid); 
            oldBid.Accepted = 1;
            currentModule.HoursFilled+=oldBid.HoursBid;
            this.db.SaveChanges();
        
            this.db.Bids.Update(oldBid); 
            oldBid.Accepted = BidStatus.Accepted;    
            this.db.SaveChanges();
        }

        public void DenyBid(int id)
        {
            BidModel oldBid = this.db.Bids.Find(id);
            this.db.Bids.Update(oldBid); 
            oldBid.Accepted = BidStatus.Rejected;    
            this.db.SaveChanges();
        }
    }
}
