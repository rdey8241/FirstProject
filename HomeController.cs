using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityCRUD.Models;
using Microsoft.Ajax.Utilities;

namespace EntityCRUD.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Home
        
        public ActionResult Index(string searching)
        {
            if (searching == null)
            {
                return View(db.products.ToList());
            }
            else
            {
                return View(db.products.Where(x => x.Name.StartsWith(searching)).ToList());
            }
        }
        ////public ActionResult Index(string searchTxt)
        ////{

        ////}
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public RedirectToRouteResult CreatePost()
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                TryUpdateModel(product);
                db.products.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id required...!!");
            }
            Product product = db.products.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product not found..!!");
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Product product = db.products.Find(id);
            UpdateModel(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id required...!!");
            }
            Product product = db.products.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product not found..!!");
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Cropper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cropper(int id)
        {
            return RedirectToAction("Index");
        }
    }
}