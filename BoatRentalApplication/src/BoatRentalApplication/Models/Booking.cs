using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalApplication.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int BoatId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerSocialSecurityNumber { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double RentalCost { get; set; }
        public bool Active { get; set; }
        public Boat Boat { get; set; }
        public Customer Customer { get; set; }

        public double CalculateCost(string category, DateTime rentalDate, DateTime returnDate)
        {
            var hours = (returnDate - rentalDate).TotalHours;
            if (category == "Segelbåt < 40 fot")
            {
                return Math.Round(((200 * 1.2) + ((100 * 1.3) * hours)),2);
            }
            else if (category == "Segelbåt > 40 fot")
            {
                return Math.Round(((200 * 1.5) + ((100 * 1.4) * hours)),2);
            }
            else
            {
                return Math.Round((200 + (100 * hours)),2);
            }
        }
    }
}
