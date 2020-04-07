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
    public class TreeService : ITreeRepository<int, API.Tree>
    {
        private ITreeRepository<int, FTDAL.Tree> _repo = new TreeRepository();
        public void Add(Tree entity)
        {
            _repo.Add(entity.ToDAL());
        }

        public int AddTreeWithId(Tree entity)
        {
            return _repo.AddTreeWithId(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Tree> Get()
        {
            return _repo.Get().Select(e => e.ToAPI());
        }

        public Tree Get(int id)
        {
            return _repo.Get(id).ToAPI();
        }

        public void Update(int id, Tree entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}