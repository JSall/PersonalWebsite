using PersonalWebsite.Web.CommandsAndClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebsite.Web.Controllers
{
    public class CodeExamplesController : Controller
    {

        // GET: CodeExamples
        public ActionResult MarkovChain()
        {

            MarkovChain chain = new MarkovChain(100);
            FeeDText(chain);

            return View("MarkovChain", chain);
        }

        //public ActionResult UpdateRoBenFranklin()
        //{
        //    //var Twitter= FluentTwitter
        //}


        private void FeeDText(MarkovChain model)
        {
            StringBuilder Feeder = new StringBuilder();
            string line;
            using (StreamReader reader = new StreamReader(Server.MapPath(Url.Content("~/Content/TextFiles/BenFranklin.txt"))))
            {
                while ((line = reader.ReadLine()) != null)
                {

                    var l = line.Trim();
                    if (l.Length > 3)
                        Feeder.AppendLine(l);
                    else if (Feeder.Length > 0)
                    {
                        model.AddString(Feeder.ToString());
                        Feeder.Length = 0;

                    }

                }
                if (Feeder.Length > 0)
                    model.AddString(Feeder.ToString());
            }
           
        }
    }
}