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
        //startsida
        public IActionResult Index()
        {
            var boats = repository.Boats();
            return View(boats);
        }
        //Bokning
        [HttpPost]
        public IActionResult Reserve(int BoatId, int CategoryId)
        {
            var bvm = repository.bookingViewModel(BoatId, CategoryId);
            return View(bvm);            
        }
        //Slutför bokning
        [HttpPost]
        public IActionResult CompleteBooking(int BoatId,int CategoryId, int CustomerId)
        {            
            var rentalDate = DateTime.Now;
            var booking = repository.BookBoat(BoatId, CategoryId, CustomerId,rentalDate);
            return View(booking);
        }
        //aktiva bokningar
        public IActionResult Bookings()
        {
            return View(repository.Bookings());
        }
        //återlämning av båt
        [HttpPost]
        public IActionResult Checkout(int BookingId)
        {
            
            return View(repository.CheckoutBooking(BookingId));
        }        
        //inaktiva bokningar
        public IActionResult PreviousBookings()
        {
            return View(repository.PreviousBookings());
        }        
        //Lägga till ny kund
        public IActionResult AddCustomer()
        {
            return View();
        }
        //tar emot kunduppgifter för ny kund
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid) { 
            repository.AddCustomer(customer);
            return RedirectToAction("Index");
            }
            return View();
        }
        //Lägg till ny båt
        public IActionResult AddBoat()
        {
            return View(repository.BoatViewModel());
        }
        //tar emot uppgifter om ny båt
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddBoat(Boat boat)
        {
            if (ModelState.IsValid) { 
            repository.AddBoat(boat);
            return RedirectToAction("Index");
            }
            return View(repository.BoatViewModel());
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
