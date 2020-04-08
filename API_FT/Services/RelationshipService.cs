using API_FT.Models;
using API_FT.Services.Mapper;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API = API_FT.Models;
using FTDAL = DAL.Models;

namespace API_FT.Services
{
    public class RelationshipService : IRelationshipRepository<int, API.Relationship>
    {
        private IRelationshipRepository<int, FTDAL.Relationship> _repo = new RelationshipRepository();
        public void Add(Relationship entity)
        {
            _repo.Add(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Relationship> Get()
        {
           return _repo.Get().Select(e => e.ToAPI());
        }

        public Relationship Get(int id)
        {
            return _repo.Get(id).ToAPI();
        }

        public IEnumerable<Relationship> GetRelationships(int id)
        {
            return _repo.GetRelationships(id).Select(e => e.ToAPI());
        }

        public IEnumerable<Relationship> GetRelationshipsFromTree(int id)
        {
            return _repo.GetRelationshipsFromTree(id).Select(e => e.ToAPI());
        }

        public void Update(int id, Relationship entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}