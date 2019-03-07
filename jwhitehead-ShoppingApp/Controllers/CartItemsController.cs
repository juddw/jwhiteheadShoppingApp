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
    public class CartItemsController : Universal
    {

        // GET: CartItems
        [Authorize] // redirects you to the login screen if not logged in.
        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            return View(user.CartItems.ToList());
        }

        // GET: CartItems/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CartItem cartItem = db.CartItems.Find(id);
        //    if (cartItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cartItem);
        //}

        // GET: CartItems/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: CartItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( int? itemId )
        {
            var user = db.Users.Find(User.Identity.GetUserId());

            if(itemId != null || user != null)
            {        
                CartItem cartItem = new CartItem();
                cartItem.ItemId = (int)itemId;
                cartItem.CustomerId = user.Id;
                cartItem.Count = 1;
                cartItem.Created = DateTime.Now;

                db.CartItems.Add(cartItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: CartItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // POST: CartItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemId,CustomerId,Count,Created")] CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartItem);
        }

        // GET: CartItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return HttpNotFound();
            }
            return View(cartItem);
        }

        // POST: CartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            db.CartItems.Remove(cartItem);
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
