using API_FT.Models;
using API_FT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API_FT.Controllers
{

    [RoutePrefix("api")]
    public class RelationshipController : ApiController
    {
        private RelationshipService _service = new RelationshipService();

        [AcceptVerbs("POST")]
        [Route("Relationship")]
        public void Register(Relationship relationship)
        {
            _service.Add(relationship);
        }

        [AcceptVerbs("DELETE")]
        [Route("Relationship/{id}")]
        public void Remove(int id)
        {
            _service.Delete(id);
        }

        [AcceptVerbs("GET")]
        [Route("Relationship")]
        public IEnumerable<Relationship> RetrieveAll()
        {
            return _service.Get();
        }

        [AcceptVerbs("GET")]
        [Route("Relationship/{id}")]
        public Relationship Retrieve(int id)
        {
            return _service.Get(id);
        }

        [AcceptVerbs("PUT")]
        [Route("Relationship/{id}")]
        public void Update(int id, Relationship relationship)
        {
            _service.Update(id, relationship);
        }

        [AcceptVerbs("GET")]
        [Route("Relationship/AllPerson/{id}")]
        public IEnumerable<Relationship> RetrieveRelationships(int id)
        {
            return _service.GetRelationships(id);
        }

        [AcceptVerbs("GET")]
        [Route("Relationship/FromTree/{id}")]
        public IEnumerable<Relationship> RetrieveRelationshipsFromTree(int id)
        {
            return _service.GetRelationshipsFromTree(id);
        }
    }
}