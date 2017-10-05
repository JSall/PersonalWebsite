using PersonalWebsite.Web.CommandsAndClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TweetSharp;

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

        public ActionResult UpdateRoBenFranklin()
        {
            List<string> model = new List<string>();
            MarkovChain chain = new MarkovChain(100);
            FeeDText(chain);

            var service = new TwitterService("K47rQlImnCUoRFTnVtB2yJfaN", "5Wv4cjWfRsWZO5LuWLxldCh0AU8GBYQVAyfODnhzhkGEp5r1BG");
            service.AuthenticateWith("722475012255563776-Ukvwm59B9U94AGo014K0TJA2h5zUWot", "v1qWB8Bs9KPZHyQccHozpsGb85wHrRGYW76lJEsdCd6Y9");

            
            

            for (int i = 0; i < 15; i++)
            {
                string generate = chain.ToString(25);
                while (generate.Length < 140)
                {
                    generate += " "+chain.ToString(25);
                }
                string msg = generate.Substring(0, 140);
                var tweet = new SendTweetOptions { Status = msg };
                service.SendTweet(tweet);
                model.Add(msg);

            }
            


            return View(model);
        }


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