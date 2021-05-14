using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using System.Text.Json;
using Business;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Hosting.Internal;

namespace EscapeRoute.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameDataController : ControllerBase
    {
        IDataBLL dataBLL;

        public GameDataController(IDataBLL dataBLL) 
        {
            this.dataBLL = dataBLL;
        }

        [HttpGet]
        public string Welcome()
        {
            return "Program Start Welcome!";
        }

        [HttpPost]
        public ResponseModel AcquireCoordinates(ReceiveModel receiveModel)
        {

           int returnCode = dataBLL.RecordToCSV(receiveModel);
            ResponseModel responseModel = new ResponseModel();
            if (returnCode == 100)
            {
                responseModel.Status = 235;
                responseModel.Msg = "Store Success";
                return responseModel;
            }
            else 
            {
                responseModel.Status = -100;
                responseModel.Msg = "Store Fail";
                return responseModel;
            }
        }


        [HttpPost]
        public ResponseModel AcquireCoordinatesBlob(ReceiveModel receiveModel)
        {

            int returnCode = dataBLL.RecordToBlobCSV(receiveModel);
            ResponseModel responseModel = new ResponseModel();
            if (returnCode == 100)
            {
                responseModel.Status = 235;
                responseModel.Msg = "Store Success";
                return responseModel;
            }
            else
            {
                responseModel.Status = -100;
                responseModel.Msg = "Store Fail";
                return responseModel;
            }
        }
    }

    

}
