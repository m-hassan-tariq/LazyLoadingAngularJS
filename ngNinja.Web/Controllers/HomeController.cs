using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;
using ngNinja.Web.Models;

namespace ngNinja.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCandidateData()
        {
            List<Candidate> people = new List<Candidate>{
                       new Candidate{candidate_id = 1, first_name = "Scott", last_name = "Gurthie", middle_initial = "AA", email = "h@aa.com", expected_salary = 15000},
                       new Candidate{candidate_id = 2, first_name = "Bill", last_name = "Gates", middle_initial = "BB", email = "B@aa.com", expected_salary = 35000}
                   };
            return Json(people, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSecondaryCandidateData()
        {
            List<Candidate> people = new List<Candidate>{
                       new Candidate{candidate_id = 11, first_name = "John", last_name = "Zack", middle_initial = "AA", email = "jj@aa.com", expected_salary = 85000},
                       new Candidate{candidate_id = 22, first_name = "Jack", last_name = "Craig", middle_initial = "BB", email = "cc@aa.com", expected_salary = 95000}
                   };
            return Json(people, JsonRequestBehavior.AllowGet);
        }
    }
}
