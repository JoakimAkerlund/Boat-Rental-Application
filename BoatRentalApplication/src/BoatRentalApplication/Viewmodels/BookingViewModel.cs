using BoatRentalApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalApplication.Viewmodels
{
    public class BookingViewModel
    {
        public Boat Boat { get; set; }
        public Category Category { get; set; }
        public List<Customer> Customers { get; set; }
        
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
       
    }
}
