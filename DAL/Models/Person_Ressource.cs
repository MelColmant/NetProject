using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Person_Ressource
    {
        public int Person_RessourceId { get; set; }
        public int PersonId { get; set; }
        public int RessourceId { get; set; }
    }
}
