using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_FT.Models
{
    public class Relationship
    {
        public int RelationshipId { get; set; }
        public int Person1Id { get; set; }
        public int Person2Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsUnisex { get; set; }
        public string RelationshipTypeCode { get; set; }
    }
}