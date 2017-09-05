using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jwhiteheadShoppingApp.Models;
using jwhiteheadShoppingApp.Models.CodeFirst;
using Microsoft.AspNet.Identity;

namespace jwhiteheadShoppingApp.Controllers
{
    public class OrdersController : Universal
    {

        // GET: Orders
        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());

            return View(user.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            // don't allow someone else to access order details if it's not their order.
            var user = db.Users.Find(User.Identity.GetUserId());
            if (order.CustomerId != user.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,City,State,ZipCode,Country,Phone,Total,OrderDate,CustomerId")] Order order, decimal total)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                order.CustomerId = user.Id;
                order.OrderDate = System.DateTime.Now;
                order.Total = total;
                db.Orders.Add(order);
                db.SaveChanges(); // order gets an id number here.

                foreach (var cartItem in user.CartItems.ToList()) // puts items in a list and closes the database connection.
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.ItemId = cartItem.ItemId;
                    orderItem.OrderId = order.Id; // has id here because it was added to the db above.
                    orderItem.Quantity = cartItem.Count;
                    orderItem.UnitPrice = cartItem.Item.Price;
                    db.OrderItems.Add(orderItem);
                    db.CartItems.Remove(cartItem);
                    db.SaveChanges();
                }
                return RedirectToAction("Details", new { id = order.Id });
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Address,City,State,ZipCode,Country,Phone,Total,OrderDate,CustomerId")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(order);
        //}

        ////GET: Orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        ////POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    db.Orders.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Orders/Confirm
        public ActionResult Confirm()
        {
            return View();
        }

        //// POST: Orders/Confirm
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Confirm([Bind(Include = "Id,Address,City,State,ZipCode,Country,Phone,Total,OrderDate,CustomerId")] Order order, decimal total)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = db.Users.Find(User.Identity.GetUserId());
        //        order.CustomerId = user.Id;
        //        order.OrderDate = System.DateTime.Now;
        //        order.Total = total;
        //        db.Orders.Add(order);
        //        db.SaveChanges(); // order gets an id number here.

        //        foreach (var cartItem in user.CartItems.ToList()) // puts items in a list and closes the database connection.
        //        {
        //            OrderItem orderItem = new OrderItem();
        //            orderItem.ItemId = cartItem.ItemId;
        //            orderItem.OrderId = order.Id; // has id here because it was added to the db above.
        //            orderItem.Quantity = cartItem.Count;
        //            orderItem.UnitPrice = cartItem.Item.Price;
        //            db.OrderItems.Add(orderItem);
        //            db.CartItems.Remove(cartItem);
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("Confirm", new { id = order.Id });
        //    }

        //    return View(order);
        //}
    }
}
