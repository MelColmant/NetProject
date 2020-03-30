using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_FT.Models
{
    public class Ressources
    {
        public int RessourceId { get; set; }
        public string Format { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}