using BoatRentalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalApplication.Data
{
    public class DbInitializer
    {
        //fyller databasen med ett antal objekt första gången
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Boat.Any())
            {
                return;
            }
            
            var cat1 = new Category { Type = "Jolle" };
            var cat2 = new Category { Type = "Segelbåt < 40 fot" };
            var cat3 = new Category { Type = "Segelbåt > 40 fot" };
           
            var boats = new List<Boat>()
            {
                new Boat {Name="Båt1", Price="grundavgift + timpris * antal timmar",Category=cat1,Available=true },
                new Boat {Name="Båt2",Price="grundavgift * 1.2 + timpris * 1.3 * antal timmar",Category=cat2,Available=true },
                new Boat {Name="Båt3",Price="grundavgift * 1.5 + timpris * 1.4 * antal timmar",Category=cat3,Available=true},
                new Boat {Name="Båt4", Price="grundavgift + timpris * antal timmar",Category=cat1,Available=true },
                new Boat {Name="Båt5",Price="grundavgift * 1.2 + timpris * 1.3 * antal timmar",Category=cat2,Available=true },
                new Boat {Name="Båt6",Price="grundavgift * 1.5 + timpris * 1.4 * antal timmar",Category=cat3,Available=true},
            };
            foreach (var boat in boats)
            {
                context.Boat.Add(boat);
            }
            context.SaveChanges();
            var customers = new List<Customer>()
            {
                new Customer {FirstName="Joakim",LastName="Åkerlund",Address="Sjösavägen",Email="joakim.akerlund@hotmail.com",Phone="070-2296422",SocialSecurityNumber="890205" },
                new Customer {FirstName="Kalle",LastName="Karlsson",Address="Stockholmsvägen",Email="kallekarlsson@gmail.com",Phone="070-1234567",SocialSecurityNumber="720613" },
                new Customer {FirstName="Anders",LastName="Andersson",Address="Vasagatan",Email="ander.andersson@gmail.com",Phone="070-7654321",SocialSecurityNumber="651123" },
            };
            foreach (var cust in customers)
            {
                context.Customer.Add(cust);
            }
            context.SaveChanges();
        }
    }
}
