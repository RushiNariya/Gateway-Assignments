using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing_Assignment_1.Models
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
    }
}