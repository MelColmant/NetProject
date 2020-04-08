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
    public class PersonService : IPersonRepository<int, API.Person>
    {
        private IPersonRepository<int, FTDAL.Person> _repo = new PersonRepository();

        public void Add(Person entity)
        {
            _repo.Add(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Person> Get()
        {
            return _repo.Get().Select(e => e.ToAPI());
        }

        public Person Get(int id)
        {
            return _repo.Get(id).ToAPI();
        }

        public IEnumerable<Person> GetAllFromTree(int id)
        {
            return _repo.GetAllFromTree(id).Select(e => e.ToAPI());
        }

        public IEnumerable<Person> GetChildren(int id)
        {
            return _repo.GetChildren(id).Select(e => e.ToAPI());
        }

        public IEnumerable<Person> GetChildrenRel(int id1, int id2)
        {
            return _repo.GetChildrenRel(id1, id2).Select(e => e.ToAPI());
        }

        public IEnumerable<Person> GetParents(int id)
        {
            return _repo.GetParents(id).Select(e => e.ToAPI());
        }

        public IEnumerable<Person> GetSiblings(int id)
        {
            return _repo.GetSiblings(id).Select(e => e.ToAPI());
        }

        public void Update(int id, Person entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}