using Identity.DAL;
using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize]
    public class EndUserController : Controller
    {
        private UserContext db = new UserContext();
        //AutoComplete Method for search text
        public ActionResult Autocomplete(string term)
        {
            var endUser = db.EndUser
                            .Where(u => u.Email.StartsWith(term))
                            .Select(u => new { label = u.Email });

            return Json(endUser, JsonRequestBehavior.AllowGet);
        }

        // GET: EndUser
        public ActionResult Index(string searchString)
        {
            var endUser = from u in db.EndUser select u;
            if (!String.IsNullOrEmpty(searchString))
            {
                endUser = endUser.Where(u => u.Email.StartsWith(searchString));
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_EndUserList", endUser.ToList());
                }
                return View(endUser.ToList());
            }

            return View(endUser.ToList());
        }

        //Get : EndUser
        public ActionResult Create()
        {
            return View();
        }
        //Post : Create EndUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EndUser endUser)
        {
            if (ModelState.IsValid)
            {
                db.EndUser.Add(endUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(endUser);
        }

        //Get : Details EndUser
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var endUser = db.EndUser.Find(id);
            if (endUser == null)
            {
                return HttpNotFound();
            }
            return View(endUser);
        }

        //Get :Edit EndUser
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var endUser = db.EndUser.Find(id);
            if (endUser == null)
            {
                return HttpNotFound();
            }
            return View(endUser);
        }

        //Post : Edit endUser
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, EndUser endUser)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = db.EndUser.Find(id);
            if (TryUpdateModel(result, "", new string[] { "Email", "DateOfJOining", "Password", "ContactNo", "Gender", "DateOfBirth", "AddressObject" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to Update");
                }
            }
            return View(endUser);
        }
        //Get : Delete EndUser
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EndUser endUser = db.EndUser.Find(id);
            if (endUser == null)
            {
                return HttpNotFound();
            }
            return View(endUser);
        }

        //Post : Delete EndUser
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, EndUser endUser)
        {
            var resultEndUser = db.EndUser.Find(id);
            var address = db.Address.Find(resultEndUser.AddressObject.Id);
            db.EndUser.Remove(resultEndUser);
            db.Address.Remove(address);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}