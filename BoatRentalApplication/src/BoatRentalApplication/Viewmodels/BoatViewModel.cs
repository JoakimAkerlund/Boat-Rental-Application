using BoatRentalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentalApplication.Viewmodels
{
    public class BoatViewModel
    {
        public Boat Boat { get; set; }
        public List<Category> Category { get; set; }
    }
}
