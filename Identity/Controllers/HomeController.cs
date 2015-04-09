using Identity.DAL;
using Identity.Models;
using Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            //return View();

            IQueryable<JoiningDateGroup> data = from productOwner in db.ProductOwners
                                                group productOwner by productOwner.DateOfJoining into dateGroup
                                                select new JoiningDateGroup()
                                                   {
                                                       DateOfJoining = dateGroup.Key,
                                                       UserCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}