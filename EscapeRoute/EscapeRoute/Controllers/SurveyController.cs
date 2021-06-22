using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Surveys;
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
        ISurveyBLL _surveyBLL;

        public SurveyController(ISurveyBLL surveyBLL)
        {
            _surveyBLL = surveyBLL;
        }

        [HttpGet]
        public string Welcome()
        {
            return "SurveyController Start Welcome!";
        }

        [HttpPost]
        public ResponseModel AcquireSurveyP1(ReceivedSurveyInfo receivedSurveyInfo)
        {
            int returnCode = _surveyBLL.RecordToPreCSV(receivedSurveyInfo);


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
        public ResponseModel AcquireSurveyP2(ReceivedSurveyInfo receivedSurveyInfo)
        {
            int returnCode = _surveyBLL.RecordToPreCSV(receivedSurveyInfo);


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
