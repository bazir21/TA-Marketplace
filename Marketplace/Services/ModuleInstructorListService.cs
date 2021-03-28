using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Marketplace.Models;
using Marketplace.Data;
using Microsoft.AspNetCore.Hosting;

namespace Marketplace.Services
{
    public class ModuleInstructorListService
    {

        private readonly MarketplaceContext db;
        public ModuleInstructorListService(MarketplaceContext db)
        {
            this.db = db;
        }

        public IEnumerable<ModuleModel> GetModules()
        {
            return db.Modules.ToList();
        }
    }
}