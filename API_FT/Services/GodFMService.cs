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
    public class GodFMService : IRepository<int, API.GodFM>
    {
        private IRepository<int, FTDAL.GodFM> _repo = new GodFMRepository();
        public void Add(GodFM entity)
        {
            _repo.Add(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<GodFM> Get()
        {
            return _repo.Get().Select(e => e.ToAPI());
        }

        public GodFM Get(int id)
        {
            return _repo.Get(id).ToAPI();
        }

        public void Update(int id, GodFM entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}