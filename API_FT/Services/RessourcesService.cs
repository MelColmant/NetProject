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
    public class RessourcesService : IRepository<int, API.Ressources>
    {
        private IRepository<int, FTDAL.Ressources> _repo = new RessourcesRepository();

        public void Add(Ressources entity)
        {
            _repo.Add(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Ressources> Get()
        {
            return _repo.Get().Select(e => e.ToAPI());
        }

        public Ressources Get(int id)
        {
            return _repo.Get(id).ToAPI();
        }

        public void Update(int id, Ressources entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}