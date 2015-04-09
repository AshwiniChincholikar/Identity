using Identity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Identity.DAL
{
    public class UserContext : DbContext
    {
        public DbSet<ProductOwner> ProductOwners { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<EndUser> EndUser { get; set; }
    }
}