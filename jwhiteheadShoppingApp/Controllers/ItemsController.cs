using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using jwhiteheadShoppingApp.Models;
using jwhiteheadShoppingApp.Models.CodeFirst;

namespace jwhiteheadShoppingApp.Controllers
{
    public class ItemsController : Universal
    {

        // GET: Items
        public ActionResult Index() // get the Index page and display it.
        {
            var itemsData = db.Items.ToList();
            return View(itemsData); // sending list to the view
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        [Authorize(Roles = "Admin")] // this will only allow access to the Admin
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Bind ensures the values are all entered
        public ActionResult Create([Bind(Include = "Id,CreationDate,UpdatedDate,Name,Price,MediaURL,Description")] Item item, HttpPostedFileBase image)
        {
            // Validation.
            if (image != null && image.ContentLength > 0) // checking to make sure there is a file, and that the file has more than 0 bytes of information.
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format."); // Don't need curly braces with only one line of code.
            }

            if (ModelState.IsValid)
            {
                var filePath = "/assets/images/"; // url path
                var absPath = Server.MapPath("~" + filePath);  // physical file path
                item.MediaURL = filePath + image.FileName; // path of the file
                image.SaveAs(Path.Combine(absPath, image.FileName)); // saves
                item.CreationDate = System.DateTime.Now;
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreationDate,UpdatedDate,Name,Price,MediaURL,Description")] Item item, string mediaURL, HttpPostedFileBase image)
        {
            // Validation.
            if (image != null && image.ContentLength > 0) // checking to make sure there is a file, and that the file has more than 0 bytes of information.
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format."); // Don't need curly braces with only one line of code.
            }

            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                if (image != null)
                {
                    var filePath = "/assets/images/"; // url path
                    var absPath = Server.MapPath("~" + filePath);  // physical file path
                    item.MediaURL = filePath + image.FileName; // path of the file
                    image.SaveAs(Path.Combine(absPath, image.FileName)); // saves
                }
                else
                {
                    item.MediaURL = mediaURL;
                }
                item.UpdatedDate = System.DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            var absPath = Server.MapPath("~" + item.MediaURL);  // physical file path
            System.IO.File.Delete(absPath);
            db.Items.Remove(item);
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
