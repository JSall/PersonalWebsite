using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebsite.Web.Controllers
{
    public class CVController : Controller
    {
        // GET: CV
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Portfolio()
        {
            return View();

        }

        public ActionResult References()
        {
            return View();
        }

        public ActionResult DownloadCV()
        {
            string filename = "Resume.docx";
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Content\\" + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}