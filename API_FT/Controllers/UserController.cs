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
    public class UserController : ApiController
    {
        private UserService _service = new UserService();

        [AcceptVerbs("POST")]
        [Route("User")]
        public bool Register(User user)
        {
           return _service.AddUser(user);
        }

        [AcceptVerbs("DELETE")]
        [Route("User/{id}")]
        public void Remove(int id)
        {
            _service.RemoveUser(id);
        }

        [AcceptVerbs("POST")]
        [Route("User/check")]
        public User CheckUser(User user)
        {
            return _service.CheckUser(user.UserName, user.Password);
        }

        [AcceptVerbs("GET")]
        [Route("User")]
        public IEnumerable<User> RetrieveAll()
        {
            return _service.Get();
        }

        [AcceptVerbs("GET")]
        [Route("User/{id}")]
        public User Retrieve(int id)
        {
            return _service.Get(id);
        }

        [AcceptVerbs("PUT")]
        [Route("User/{id}")]
        public void Update(int id, User user)
        {
            _service.Update(id, user);
        }
    }
}