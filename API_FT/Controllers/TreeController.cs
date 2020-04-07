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
    public class TreeController : ApiController
    {
        private TreeService _service = new TreeService();

        [AcceptVerbs("POST")]
        [Route("Tree")]
        public void Register(Tree tree)
        {
            _service.Add(tree);
        }

        [AcceptVerbs("POST")]
        [Route("TreeWithId")]
        public int RegisterWithId(Tree tree)
        {
           return _service.AddTreeWithId(tree);
        }

        [AcceptVerbs("DELETE")]
        [Route("Tree/{id}")]
        public void Remove(int id)
        {
            _service.Delete(id);
        }

        [AcceptVerbs("GET")]
        [Route("Tree")]
        public IEnumerable<Tree> RetrieveAll()
        {
            return _service.Get();
        }

        [AcceptVerbs("GET")]
        [Route("Tree/{id}")]
        public Tree Retrieve(int id)
        {
           return _service.Get(id);
        }

        [AcceptVerbs("PUT")]
        [Route("Tree/{id}")]
        public void Update(int id, Tree tree)
        {
            _service.Update(id, tree);
        }


    }
}