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

        [HttpGet]
        public ResponseModel PlayerCheck(string playerUuid)
        {
            ResponseModel responseModel = new ResponseModel();
            if (playerUuid != null)
            {
                int returnCode = _surveyBLL.PlayerSurveyCheck(playerUuid);

                if (returnCode > 0)
                {
                    responseModel.Status = 235;
                    responseModel.Msg = "Survey Completed";
                    return responseModel;
                }
                else
                {
                    responseModel.Status = -100;
                    responseModel.Msg = "No Record!";
                    return responseModel;
                }
            }
            else
            {
                responseModel.Status = -100;
                responseModel.Msg = "No ID received!";
                return responseModel;
            }
        }

        [HttpPost]
        public ResponseModel AcquireSurveyP1(ReceivedSurveyInfo receivedSurveyInfo)
        {
            ResponseModel responseModel = new ResponseModel();
            if (receivedSurveyInfo != null)
            {
                int returnCode = _surveyBLL.RecordToPreCSV(receivedSurveyInfo);
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
            else
            {
                responseModel.Status = -100;
                responseModel.Msg = "No data received";
                return responseModel;
            }
        }

        [HttpPost]
        public ResponseModel AcquireSurveyP2(ReceivedPostSurveyInfo receivedSurveyInfo)
        {
            ResponseModel responseModel = new ResponseModel();
            if (receivedSurveyInfo != null)
            {
                int returnCode = _surveyBLL.RecordToPostCSV(receivedSurveyInfo);
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
            else
            {
                responseModel.Status = -100;
                responseModel.Msg = "No data received";
                return responseModel;
            }
        }
    }
}
