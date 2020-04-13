using API_FT.Models;
using API_FT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ToolBox.JWT;

namespace API_FT.Controllers
{
    [RoutePrefix("api")]
    public class SecurityController : ApiController
    {
        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login(LoginModel model)
        {
            UserService s = new UserService();
            User user = s.CheckUser(model.Username, model.Password);
            int id = user.UserId;
            if (id == 0)
            { return Unauthorized(); }
            else
            {
                JWTService service = new JWTService(
                    "dfjlkwdlsdjtiorxkbS&",
                    "localhost",
                    "postman"
                    );
                return Ok(service.Encode(user));
            }
        }
    }
}