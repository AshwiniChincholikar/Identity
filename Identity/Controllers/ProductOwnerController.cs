using Identity.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using Identity.DAL;

namespace Identity.Controllers
{
    [Authorize]
    public class ProductOwnerController : Controller
    {
        private UserContext db = new UserContext();
        // GET: ProductOwner
        public ActionResult Index(string sortOrder,string searchString,string currentFilter,int? page)
        {
            // return View();
            //    return View(db.ProductOwners.ToList());
            /*****************************************************/
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var owners = from o in db.ProductOwners select o;

            if (!String.IsNullOrEmpty(searchString))
            {
                owners = owners.Where(o => o.CompanyName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    owners = owners.OrderByDescending(o => o.CompanyName);
                    break;
                case "Date":
                    owners = owners.OrderBy(o => o.DateOfJoining);
                    break;
                case "date_desc":
                    owners = owners.OrderByDescending(o => o.DateOfJoining);
                    break;
                default:
                    owners = owners.OrderBy(o => o.CompanyName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            /**
             * The ToPagedList method takes a page number. 
             * The two question marks represent the null-coalescing operator. 
             * The null-coalescing operator defines a default value for a nullable type;
             * the expression (page ?? 1) means return the value of page if it has a value, 
             * or return 1 if page is null.
             * */
            return View(owners.ToPagedList(pageNumber,pageSize));
        }

        //Get : ProductOwner
        public ActionResult Create()
        {
            return View();
        }
        //Post : Create ProductOwner
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductOwner productOwner)
        {
            if (ModelState.IsValid)
            {
                db.ProductOwners.Add(productOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productOwner);
        }

        //Get : Details ProductOwner
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productOwner = db.ProductOwners.Find(id);
            if (productOwner == null)
            {
                return HttpNotFound();
            }
            return View(productOwner);
        }

        //Get :Edit ProductOwner
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          //  var productOwner = db.ProductOwners.Single(p => p.Id == id);
            var productOwner = db.ProductOwners.Find(id);
            if (productOwner == null)
            {
                return HttpNotFound();
            }
            return View(productOwner);
        }

        //Post : Edit ProductOwner
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, ProductOwner productOwner)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = db.ProductOwners.Find(id);
            if (TryUpdateModel(result, "", new string[] { "Email", "DateOfJOining", "Password", "ContactNo", "CompanyName", "Description", "FoundedIn", "WebsiteUrl", "TwitterUrl", "FbUrl", "AddressObject" }))
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
            return View(productOwner);
        }
        //Get : Delete ProductOwner
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOwner productOwner = db.ProductOwners.Find(id);
            if (productOwner == null)
            {
                return HttpNotFound();
            }
            return View(productOwner);
        }

        //Post : Delete ProductOwner
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, ProductOwner productOwner)
        {
            var resultProductOwner = db.ProductOwners.Find(id);
            var address = db.Address.Find(resultProductOwner.AddressObject.Id);
            db.ProductOwners.Remove(resultProductOwner);
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