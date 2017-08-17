using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jwhiteheadShoppingApp.Models.CodeFirst
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string CustomerId { get; set; } // This is the Foreign Key.
        public int Count { get; set; }
        public DateTime Created { get; set; }

        public virtual Item Item { get; set; }
        public virtual ApplicationUser Customer { get; set; } // naming convention. Foreign Key needs to be this name + Id.

        public decimal unitTotal
        {
            get
            {
                return Count * Item.Price;
            }
        }
    }
}