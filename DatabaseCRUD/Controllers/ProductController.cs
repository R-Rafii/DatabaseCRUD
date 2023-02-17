using DatabaseCRUD.EF;
using DatabaseCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseCRUD.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Product model)
        {
            //if (ModelState.IsValid) { }
            //dbinsert
            var db = new Test02Entities();
            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var db = new Test02Entities();
            var list = db.Products.ToList();
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            var db = new Test02Entities();
            var ed = (from s in db.Products
                           where s.Id == id
                           select s).SingleOrDefault();
            return View(ed);
        }
        [HttpPost]
        public ActionResult Edit(Product updated)
        {
            var db = new Test02Entities();
            var upd = (from s in db.Products
                              where s.Id == updated.Id
                              select s).SingleOrDefault();
            //upd.Name = updated.Name;
            //upd.Price = updated.Price;
            //upd.Qty = updated.Qty;
            db.Entry(upd).CurrentValues.SetValues(updated);
            db.SaveChanges();
            return RedirectToAction("List");
            
        }
        
        public ActionResult Delete(Product updated)
        {
            var db = new Test02Entities();
            var upd = (from s in db.Products
                       where s.Id == updated.Id
                       select s).SingleOrDefault();
            db.Products.Remove(upd);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}