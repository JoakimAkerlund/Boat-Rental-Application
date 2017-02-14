using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BoatRentalApplication.Models;
using BoatRentalApplication.Data;

namespace BoatRentalApplication.Controllers
{
    public class HomeController : Controller
    {
        private IAppRepository repository;
        public HomeController(IAppRepository repo)
        {
            repository = repo;            
        }
        public IActionResult Index()
        {
            var boats = repository.Boats();
            return View(boats);
        }
        
        [HttpPost]
        public IActionResult Reserve(int BoatId, int CategoryId)
        {
            var bvm = repository.bookingViewModel(BoatId, CategoryId);
            return View(bvm);            
        }
        [HttpPost]
        public IActionResult CompleteBooking(int BoatId,int CategoryId, int CustomerId)
        {            
            var rentalDate = DateTime.Now;
            var booking = repository.BookBoat(BoatId, CategoryId, CustomerId,rentalDate);
            return View(booking);
        }
        public IActionResult Bookings()
        {
            return View(repository.Bookings());
        }
        [HttpPost]
        public IActionResult Checkout(int BookingId)
        {
            
            return View(repository.CheckoutBooking(BookingId));
        }        
        public IActionResult PreviousBookings()
        {
            return View(repository.PreviousBookings());
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
