using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EscapeRouteAPI.Controllers
{
    [EnableCors("any")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class FileController : Controller
    {
        IFileBLL _fileBLL;

        public FileController(IFileBLL fileBLL) 
        {
            _fileBLL = fileBLL;

        }
        [HttpGet]
        public IActionResult PreSurveyAcquire()
        {
            var fileStream = _fileBLL.PreSurveyAcquire();
            string fileName = "PreSurvey.csv";
            return ExtractFile(fileStream, fileName);
        }

        

        [HttpGet]
        public IActionResult AfterSurveyAcquire()
        {
            var fileStream = _fileBLL.PreSurveyAcquire();
            string fileName = "AfterSurvey.csv";
            return ExtractFile(fileStream, fileName);
        }

        [HttpGet]
        public IActionResult CoordinateAcquire()
        {
            var fileStream = _fileBLL.CoordinateAcquire();
            string fileName = "Coordinates.csv";
            return ExtractFile(fileStream, fileName);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AllInOneAcquire(string playerUuid)
        {
            return Ok("Eve is fine");
        }

        [HttpGet]
        public IActionResult AcquireFileSize() 
        {
            var fileSize = _fileBLL.AcquireFileSize();
            if (fileSize != null)
            {
                int passCode = 200;
                var jsonResult = new { Status = passCode, preSurvey = fileSize.Item1, afterSurvey = fileSize.Item2, recording = fileSize.Item3, };
                return Json(jsonResult);
            }
            else 
            {
                int passCode = -100;
                return Json(new { Status = passCode });
            }
        }

        [HttpDelete]
        public IActionResult DeleteFiles() 
        {
            int passCode = _fileBLL.DeleteAll();

            if (passCode == -100)
            {
                var jsonResult = new { Status = passCode, Info = "Faild" };
                return Json(jsonResult);
            }
            else 
            {
                var jsonResult = new { Status = passCode, Info = "Success" };
                return Json(jsonResult);
            }
        }

        private IActionResult ExtractFile(Stream fileStream, string fileName)
        {
            if (fileStream != null)
            {
                return File(fileStream, "application/octet-stream", fileName);
            }
            else
            {
                var jsonResult = new { Status = -100, Info = "No Content" };
                return Json(jsonResult);
            }
        }
    }
}
