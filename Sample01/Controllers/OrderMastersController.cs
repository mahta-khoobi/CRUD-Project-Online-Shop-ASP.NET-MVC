using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sample01.Models.DomainModels.DTO.EF;

namespace Sample01.Controllers
{
    public class OrderMastersController : Controller
    {
        private OnlineShopEntities db = new OnlineShopEntities();

        // GET: OrderMasters
        public ActionResult Index()
        {
            var orderMaster = db.OrderMaster.Include(o => o.Customer);
            return View(orderMaster.ToList());
        }

        // GET: OrderMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster orderMaster = db.OrderMaster.Find(id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }
            return View(orderMaster);
        }

        // GET: OrderMasters/Create
        public ActionResult Create()
        {
            ViewBag.Customer_Ref = new SelectList(db.Customer, "Id", "FirstName");
            return View();
        }

        // POST: OrderMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderCode,OrderDate,Customer_Ref")] OrderMaster orderMaster)
        {
            if (ModelState.IsValid)
            {
                db.OrderMaster.Add(orderMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_Ref = new SelectList(db.Customer, "Id", "FirstName", orderMaster.Customer_Ref);
            return View(orderMaster);
        }

        // GET: OrderMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster orderMaster = db.OrderMaster.Find(id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_Ref = new SelectList(db.Customer, "Id", "FirstName", orderMaster.Customer_Ref);
            return View(orderMaster);
        }

        // POST: OrderMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderCode,OrderDate,Customer_Ref")] OrderMaster orderMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_Ref = new SelectList(db.Customer, "Id", "FirstName", orderMaster.Customer_Ref);
            return View(orderMaster);
        }

        // GET: OrderMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMaster orderMaster = db.OrderMaster.Find(id);
            if (orderMaster == null)
            {
                return HttpNotFound();
            }
            return View(orderMaster);
        }

        // POST: OrderMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderMaster orderMaster = db.OrderMaster.Find(id);
            db.OrderMaster.Remove(orderMaster);
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
