using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        IBlobBLL blobBLL;

        public FileController(IBlobBLL blobBLL)
        {
            this.blobBLL = blobBLL;
        }

        [HttpGet]
        public IActionResult DataLocalDownLoad()
        {
            var filePath = "Temp/Recording.csv";
            var fileName = "Recording.csv";
            return File(new FileStream(filePath, FileMode.Open), "application/octet-stream", fileName);
        }

        [HttpGet]
        public IActionResult DataBlobDownLoad()
        {
            var filestring = blobBLL.GetBlobAsync2("Recording.csv");
            var fileName = "Recording.csv";
            return File(filestring.Result.Content, filestring.Result.ContentType, fileName);
        }
    }
}
