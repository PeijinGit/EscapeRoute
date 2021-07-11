using Business.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscapeRouteAPI.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        IUser _user;

        public UserController(IUser user)
        {
            _user = user;

        }
        [HttpGet]
        public IActionResult Login(string username,string password)
        {
            var user = _user.Login(username, password);
            if (user != null)
            {
                HttpContext.Response.StatusCode = 200;
                var jsonResult = new { Status = 200, userInfo = user };
                return Json(jsonResult);
            }
            else
            {
                HttpContext.Response.StatusCode = 204;
                var jsonResult = new { Status = -100, userInfo = user };
                return Json(jsonResult);
            }
        }
    }
}
