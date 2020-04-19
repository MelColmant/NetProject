using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_FT.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public int TreeId { get; set; }
        public int Generation { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
    }
}