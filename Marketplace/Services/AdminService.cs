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

        /*public IEnumerable<ModuleModel> GetAllModulesWithBids()
        {
            IEnumerable<ModuleModel> modules= null;
            modules.ToList().Add
        }*/
    }
}