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
    public class LoginService
    {
        private readonly MarketplaceContext db;
        public LoginService(MarketplaceContext db)
        {
            this.db = db;
        }

        public bool LoginProcess(int id, string strPassword)
        {
            bool validation= false;
            UserModel user= db.Users.Find(id);
            
            if(user!=null)
            {
                if(user.Password.Equals(strPassword))
                    validation= true;
                else 
                    validation= false;
            }
            return validation;
        }
    }
}