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
        public void Register(User user)
        {
            _service.AddUser(user);
        }

        [AcceptVerbs("DELETE")]
        [Route("User/{id}")]
        public void Remove(int id)
        {
            _service.RemoveUser(id);
        }

        [AcceptVerbs("POST")]
        [Route("User/check")]
        public int CheckUser(User user)
        {
            return _service.CheckUser(user.UserName, user.Password);
        }
    }
}