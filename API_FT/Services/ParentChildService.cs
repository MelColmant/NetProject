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
    public class ParentChildService : IParentChildRepository<int, API.ParentChild>
    {
        private IParentChildRepository<int, FTDAL.ParentChild> _repo = new ParentChildRepository();
        public void Add(ParentChild entity)
        {
            _repo.Add(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<ParentChild> Get()
        {
            return _repo.Get().Select(e => e.ToAPI());
        }

        public ParentChild Get(int id)
        {
            return _repo.Get(id).ToAPI();
        }

        public IEnumerable<ParentChild> GetParentChildFromTree(int id)
        {
            return _repo.GetParentChildFromTree(id).Select(e => e.ToAPI());
        }

        public void Update(int id, ParentChild entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}