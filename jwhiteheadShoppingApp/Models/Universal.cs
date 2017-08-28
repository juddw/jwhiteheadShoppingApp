using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jwhiteheadShoppingApp.Models
{
    public class Universal : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (User.Identity.IsAuthenticated)
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                ViewBag.FirstName = user.FirstName;
                ViewBag.LastName = user.LastName;
                ViewBag.FullName = user.FullName;
                // c is just a variable. c is like a foreach loop setting we want the cartItems where the CustomerId == the current logged in user's id.
                ViewBag.CartItems = db.CartItems.AsNoTracking().Where(c=>c.CustomerId == user.Id).ToList(); // must use AsNoTracking because Universal already has
                // a connection open. This leaves no trace and does not affect the current open connection.
                ViewBag.TotalCartitems = user.CartItems.Sum(c => c.Count);
                ViewBag.CartTotalCost = user.CartItems.Sum(c => c.unitTotal);
            }
        }
    }
}