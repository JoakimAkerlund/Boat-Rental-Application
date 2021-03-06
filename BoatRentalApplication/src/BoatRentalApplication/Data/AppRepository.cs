﻿using BoatRentalApplication.Models;
using BoatRentalApplication.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalApplication.Data
{
    public class AppRepository:IAppRepository
    {
        private ApplicationDbContext context;
        public AppRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        //hämtar alla båtar från databasen
        public IEnumerable<Boat> Boats()
        {
            var cat = context.Category.ToList();
            var boats = context.Boat;
            return boats;
        }
        //bokning av båt
        public Booking BookBoat(int BoatId, int CategoryId, int CustomerId,DateTime rentalDate)
        {
            var customer = context.Customer.FirstOrDefault(c => c.Id == CustomerId);
            var boat = context.Boat.FirstOrDefault(b => b.Id == BoatId);
            boat.Available = false;
            var category = context.Category.FirstOrDefault(cat => cat.CategoryId == CategoryId);
            var booking = new Booking()
            {
                Boat=boat,                
                Customer=customer,
                RentalDate=rentalDate,
                BoatId=boat.Id,
                CustomerId=customer.Id,
                CustomerSocialSecurityNumber=customer.SocialSecurityNumber,  
                Active=true                          
                
            };
            context.Update(boat);
            context.Add(booking);
            context.SaveChanges();
            return booking;
        }
        //återlämning av båt
        public Booking CheckoutBooking(int BookingId)
        {
            var booking = context.Booking.FirstOrDefault(b => b.Id == BookingId);
            var boat = context.Boat.FirstOrDefault(bt => bt.Id == booking.BoatId);
            var category = context.Category.FirstOrDefault(cat => cat.CategoryId == boat.CategoryId);
            var customer = context.Customer.FirstOrDefault(cust => cust.Id == booking.CustomerId);
            booking.ReturnDate = DateTime.Now;
            //räknar ut kostnaden för båten i metoden calculateCost i klassen booking
            booking.RentalCost = booking.CalculateCost(booking.Boat.Category.Type, booking.RentalDate, booking.ReturnDate);
            //gör båten tillgänglig för uthyrning igen
            boat.Available = true;
            //ändrar bokning till inaktiv
            booking.Active = false;
            context.Update(booking);
            context.Update(boat);
            context.SaveChanges();

            return booking;
        }
        //hämtar alla aktiva ordrar
        public IEnumerable<Booking> Bookings()
        {
            var customers = context.Customer.ToList();
            var boats= context.Boat.ToList();
            var cat = context.Category.ToList();
            var bookings = context.Booking.Where(b=>b.Active==true).OrderByDescending(b=>b.RentalDate).ToList();
            return bookings;
        }
        //hämtar avslutade ordrar
        public IEnumerable<Booking> PreviousBookings()
        {
            var customers = context.Customer.ToList();
            var boats = context.Boat.ToList();
            var cat = context.Category.ToList();
            var previousBookings = context.Booking.Where(b => b.Active == false).OrderByDescending(b => b.RentalDate).ToList();
            return previousBookings;
        }
        //viewmodel för bokningsvy
        public BookingViewModel bookingViewModel(int BoatId,int CategoryId)
        {
            var BVM = new BookingViewModel();
            BVM.Boat = context.Boat.SingleOrDefault(b => b.Id == BoatId);
            BVM.Category = context.Category.SingleOrDefault(c => c.CategoryId == CategoryId);
            BVM.Customers = context.Customer.ToList();
            
            return BVM;
        }
        
        public void AddCustomer(Customer customer)
        {
            context.Customer.Add(customer);
            context.SaveChanges();
        }

        public BoatViewModel BoatViewModel()
        {
            var boatViewModel = new BoatViewModel();
            boatViewModel.Category = context.Category.ToList();
            return boatViewModel;
        }

        public void AddBoat(Boat boat)
        {
            var category = context.Category.FirstOrDefault(cat => cat.CategoryId == boat.CategoryId);
            string price;
            if(category.Type== "Segelbåt > 40 fot")
            {
                price = "grundavgift * 1.5 + timpris * 1.4 * antal timmar";
            }
            else if (category.Type == "Segelbåt < 40 fot")
            {
                price = "grundavgift * 1.2 + timpris * 1.3 * antal timmar";
            }
            else
            {
                price = "grundavgift + timpris * antal timmar";
            }
            var newBoat = new Boat()
            {
                Name=boat.Name,
                Available = true,
                CategoryId=category.CategoryId,
                Category=category,
                Price=price
            };
            context.Add(newBoat);
            context.SaveChanges();
        }
    }
    public interface IAppRepository
    {
        IEnumerable<Boat> Boats();
        BookingViewModel bookingViewModel(int BoatId, int CategoryId);
        Booking BookBoat(int BoatId, int CategoryId, int CustomerId, DateTime rentalDate);
        IEnumerable<Booking> Bookings();
        Booking CheckoutBooking(int BookingId);
        IEnumerable<Booking> PreviousBookings();
        void AddCustomer(Customer customer);
        BoatViewModel BoatViewModel();
        void AddBoat(Boat boat);
        }
    }

