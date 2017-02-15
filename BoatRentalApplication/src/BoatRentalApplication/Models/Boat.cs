using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalApplication.Models
{
    public class Boat
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fyll i ett båtnamn")]
        public string Name { get; set; }
        public string Price { get; set; }
        public int CategoryId { get; set; }
        public bool Available { get; set; }
        public Category Category { get; set; }
    }
}
