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
    public class UserService : IUserRepository<int, API.User>
    {
        private IUserRepository<int, FTDAL.User> _repo = new UserRepository();
        public void AddUser(API.User entity)
        {
            _repo.AddUser(entity.ToDAL());
        }
        public void RemoveUser(int id)
        {
            _repo.RemoveUser(id);
        }
        public int CheckUser(string username, string password)
        {
            return _repo.CheckUser(username, password);
        }
    }
}