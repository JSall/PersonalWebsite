using PersonalWebsite.Web.CommandsAndClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebsite.Web.Controllers
{
    public class CodeExamplesController : Controller
    {
        private string ex = " A vector is a sequence that supports random access to elements, constant time insertion\n" +
"and removal of elements at the end, and linear time insertion and removal of elements at\n" +
"the beginning or in the middle.The number of elements in a vector may vary\n" +
"dynamically; memory management is automatic.Vector is the simplest of the STL\n" +
"container classes, and in many cases the most efficient.\n" +
"Member functions: push_back, pop_back size.\n";
        // GET: CodeExamples
        public ActionResult MarkovChain()
        {

            MarkovChain chain = new MarkovChain(15);
            FeeDText(chain);

            return View("MarkovChain", model: chain.ToString(3));
        }

        private void FeeDText(MarkovChain model)
        {
            StringBuilder Feeder = new StringBuilder();
            var test = ex.Split("\n".ToArray());
            foreach (string line in test)
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