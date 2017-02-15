using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Fyll i förnamn")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Fyll i efternamn")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Fyll i personnummer")]
        public string SocialSecurityNumber { get; set; }
        [Required(ErrorMessage = "Fyll i email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fyll i adress")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Fyll i telefonnummer")]
        public string Phone { get; set; }
    }
}
