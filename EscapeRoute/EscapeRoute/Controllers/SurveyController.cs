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
    public class SurveyController : Controller
    {
        [HttpGet]
        public string Welcome()
        {
            return "SurveyController Start Welcome!";
        }

        [HttpPost]
        public ResponseModel AcquireSurveyP1(ReceiveModel receiveModel)
        {

            return null;
        }
    }
}
