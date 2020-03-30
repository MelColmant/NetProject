using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_FT.Models
{
    public class Person_Ressource
    {
        public int Person_RessourceId { get; set; }
        public int PersonId { get; set; }
        public int RessourceId { get; set; }
    }
}