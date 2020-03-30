using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Ressources
    {
        public int RessourceId { get; set; }
        public string Format { get; set; }
        public  string Description { get; set; }
        public string Link { get; set; }
    }
}
