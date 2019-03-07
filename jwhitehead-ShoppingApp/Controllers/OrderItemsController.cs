﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jwhiteheadShoppingApp.Models;
using jwhiteheadShoppingApp.Models.CodeFirst;

namespace jwhiteheadShoppingApp.Controllers
{
    public class OrderItemsController : Universal
    {

        //    // GET: OrderItems
        //    public ActionResult Index()
        //    {
        //        var orderItems = db.OrderItems.Include(o => o.Item).Include(o => o.Order);
        //        return View(orderItems.ToList());
        //    }

        //    // GET: OrderItems/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        OrderItem orderItem = db.OrderItems.Find(id);
        //        if (orderItem == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(orderItem);
        //    }

        //    // GET: OrderItems/Create
        //    public ActionResult Create()
        //    {
        //        ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
        //        ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address");
        //        return View();
        //    }

        //    // POST: OrderItems/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "Id,OrderId,ItemId,Quantity,UnitPrice")] OrderItem orderItem)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.OrderItems.Add(orderItem);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", orderItem.ItemId);
        //        ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderItem.OrderId);
        //        return View(orderItem);
        //    }

        //    // GET: OrderItems/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        OrderItem orderItem = db.OrderItems.Find(id);
        //        if (orderItem == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", orderItem.ItemId);
        //        ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderItem.OrderId);
        //        return View(orderItem);
        //    }

        //    // POST: OrderItems/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "Id,OrderId,ItemId,Quantity,UnitPrice")] OrderItem orderItem)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(orderItem).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", orderItem.ItemId);
        //        ViewBag.OrderId = new SelectList(db.Orders, "Id", "Address", orderItem.OrderId);
        //        return View(orderItem);
        //    }

        //    // GET: OrderItems/Delete/5
        //    [Authorize(Roles = "Admin")] // this will only allow access to the Admin
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        OrderItem orderItem = db.OrderItems.Find(id);
        //        if (orderItem == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(orderItem);
        //    }

        //    // POST: OrderItems/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        OrderItem orderItem = db.OrderItems.Find(id);
        //        db.OrderItems.Remove(orderItem);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}