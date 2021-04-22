using Marketplace.Services;
using Marketplace.Models;
using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Services
{
    public class UserService
    {
        private readonly MarketplaceContext db;
        public UserService(MarketplaceContext db)
        {
            this.db = db;
        }

        public bool UserExists(string userEmail)
        {
            IEnumerable<InstructorModel> currentUser = this.db.Instructor.Where(user => user.Email == userEmail).ToList();
            Console.WriteLine("Number of users:" + currentUser.Count());
            return currentUser.Count() != 0;
        }

        public bool AdminExists(string userEmail)
        {
            IEnumerable<AdministratorModel> currentUser = this.db.Administrators.Where(user => user.Email == userEmail).ToList();
            Console.WriteLine("Number of users:" + currentUser.Count());
            return currentUser.Count() != 0;
        }
    }
}