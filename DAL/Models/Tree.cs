using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Tree
    {
        public int TreeId { get; set; }
        public string TreeName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
