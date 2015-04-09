using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Identity.Models;

namespace Identity.DAL
{
    public class UserInitializer : System.Data.Entity.CreateDatabaseIfNotExists<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var productOwner = new List<ProductOwner>           
            {           
                new ProductOwner 
                {
                    Email = "ashwini@example.com",
                    DateOfJoining = DateTime.Parse("2014-09-01"),
                    CompanyName = "Abcd", 
                    ContactNo = 252955,
                    Description = "Software", 
                    FoundedIn = DateTime.Parse("2000-01-11"),
                    Password = "Abcd11@",
                    WebsiteUrl = "www.abc.com",
                    TwitterUrl = "", FbUrl = "",
                    AddressObject = new Address{ Street1 = "65 West Alisal St",Street2 = "",State = "CA", City = "Salinas", Pin = 93901}},
                new ProductOwner
                {
                    Email = "Scott@example.com",
                    DateOfJoining = DateTime.Parse("2012-04-09"),
                    CompanyName = "Defgh",
                    ContactNo = 252955,
                    Description = "Engineering",
                    FoundedIn = DateTime.Parse("2002-07-02"),
                    Password = "Defgh11@",
                    WebsiteUrl = "www.defgh.com",
                    TwitterUrl = "",
                    FbUrl = "",
                    AddressObject = new Address{ Street1 = "6170 Peshwar Place",Street2 = "",State = "Washington DC ",City = "",Pin = 20521-6170}
                },
                new ProductOwner
                {
                    Email = "David@example.com",
                    DateOfJoining = DateTime.Parse("2011-02-05"),
                    CompanyName = "David",
                    ContactNo = 252955,
                    Description = "Defghijk",
                    FoundedIn = DateTime.Parse("2001-02-05"),
                    Password = "David11@",
                    WebsiteUrl = "www.david.com",
                    TwitterUrl = "",
                    FbUrl = "",
                    AddressObject = new Address{ Street1 = "5520 Quebec Place",Street2 = "",State = "Washington DC ",City = "",Pin = 20521-5520}
                },
                new ProductOwner
                {
                    Email = "Mark@example.com",
                    DateOfJoining = DateTime.Parse("2013-03-03"),
                    CompanyName = "Mark",
                    ContactNo = 252955,
                    Description = "Mark Company",
                    FoundedIn = DateTime.Parse("1999-04-10"),
                    Password = "David11@",
                    WebsiteUrl = "www.mark.com",
                    TwitterUrl = "",
                    FbUrl = "", 
                    AddressObject =new Address{Street1 = "65 West Alisal St",Street2 = "",State = "CA",City = "Salinas",Pin = 93901}
                }};
            productOwner.ForEach(p => context.ProductOwners.Add(p));
            context.SaveChanges();

            var endUser = new List<EndUser>
            {           
                new EndUser
                {
                    Email = "harry@example.com",
                    DateOfJoining = DateTime.Parse("2013-03-03"),
                    DateOfBirth = DateTime.Parse("1988-03-03"),
                    ContactNo = 1234567,
                    Password = "Harry@11",
                    Gender = "Male",
                    AddressObject = new Address{Street1 = " E 2430 Nouakchott Place",Street2 = "",State = "Washington DC",City = "Salinas",Pin = 20521-2430}
                },
                new EndUser
                {
                    Email = "janet@example.com",
                    DateOfJoining = DateTime.Parse("2013-03-03"),
                    DateOfBirth = DateTime.Parse("1982-02-06"),
                    ContactNo = 1234567,
                    Password = "Janet@11",
                    Gender = "Female",
                    AddressObject = new Address{Street1 = "E 30 Mortensen Avenue",Street2 = "",State = "CA",City = "Salinas",Pin = 93905}
                },
                new EndUser
                {
                    Email = "cynthia@example.com",
                    DateOfJoining = DateTime.Parse("2014-03-04"),
                    DateOfBirth = DateTime.Parse("1988-08-05"),
                    ContactNo = 1234567,
                    Password = "Cynthia@11",
                    Gender = "Female",
                    AddressObject = new Address{Street1 = "E 33290 Hermosillo Place",Street2 = "",State = "CA",City = "Salinas",Pin = 9390}
                },
                new EndUser
                {
                    Email = "charles @example.com",
                    DateOfJoining = DateTime.Parse("2011-01-06"),
                    DateOfBirth = DateTime.Parse("1990-07-01"),
                    ContactNo = 1234567,
                    Password = "Charles @11",
                    Gender = "Male",
                    AddressObject = new Address{Street1 = "E 4150 Sydney Place",Street2 = "",State = "Washington DC",City = "Salinas",Pin = 20521 - 3290}
                }};
            endUser.ForEach(e => context.EndUser.Add(e));
            context.SaveChanges();

        }
    }
}