using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace EscapeRoute.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameDataController : ControllerBase
    {

        [HttpGet]
        public string Welcome()
        {
            return "Program Start Welcome!";
        }

        [HttpPost]
        public ReceiveModel AcquireCoordinates([FromBody]ReceiveModel receiveModel) 
        {
            return receiveModel;
        }

        [HttpPost]
        public ResponseModel TestMethod([FromBody] string st)
        {
            return null;
        }
    }
}
