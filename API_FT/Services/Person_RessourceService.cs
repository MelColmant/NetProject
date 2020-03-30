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
    public class Person_RessourceService : IRepository<int, API.Person_Ressource>
    {
        private IRepository<int, FTDAL.Person_Ressource> _repo = new Person_RessourceRepository();
        public void Add(Person_Ressource entity)
        {
            _repo.Add(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Person_Ressource> Get()
        {
            return _repo.Get().Select(e => e.ToAPI());
        }

        public Person_Ressource Get(int id)
        {
            return _repo.Get(id).ToAPI();
        }

        public void Update(int id, Person_Ressource entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}