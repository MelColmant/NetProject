using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ParentChild
    {
        public int ParentChildId { get; set; }
        public int Person1Id { get; set; }
        public int Person2Id { get; set; }
        public bool IsAdopted { get; set; }
        public int TreeId { get; set; }
    }
}
