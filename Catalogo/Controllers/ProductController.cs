using Catalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Catalogo.Controllers
{
    public class ProductController : Controller
    {
        CatalogEntities ctg = new CatalogEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(ctg.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var produto = (from cont in ctg.Products where cont.ProductID == id select cont).First();
            return View(produto);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product oProduct)
        {
            if (ModelState.IsValid)
            {
                ctg.Products.Add(oProduct);
                ctg.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(ctg.Products, "ProductID", "Name", oProduct.ProductID);
            return View(oProduct);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = (from cont in ctg.Products where cont.ProductID == id select cont).First();
            return View(produto);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product oProduct)
        {
            if (oProduct == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product prod = ctg.Products.Find(oProduct);
            if (prod == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentsId = new SelectList(ctg.Products, "ProductID", "Name", oProduct.ProductID);
            return View(oProduct);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
