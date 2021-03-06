﻿using API_FT.Models;
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
        public bool AddUser(API.User entity)
        {
            return _repo.AddUser(entity.ToDAL());
        }
        public void RemoveUser(int id)
        {
            _repo.RemoveUser(id);
        }
        public API.User CheckUser(string username, string password)
        {
            return _repo.CheckUser(username, password).ToAPI();
        }

        public IEnumerable<User> Get()
        {
            return _repo.Get().Select(e => e.ToAPI());
        }

        public User Get(int id)
        {
            return _repo.Get(id).ToAPI();
        }

        public void Update(int id, User entity)
        {
            _repo.Update(id, entity.ToDAL());
        }
    }
}