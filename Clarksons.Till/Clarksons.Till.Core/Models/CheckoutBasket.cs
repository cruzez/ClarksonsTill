using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Clarksons.Till.Core.Models
{
    public class CheckoutBasket
    {
        public CheckoutBasket()
        {
            BasketId = Guid.NewGuid().ToString();
            BasketItems = new List<CheckoutBasketItem>();
            TotalAmount = 0.0m;
        }
     
        public string BasketId { get; set; }
       
        public IList<CheckoutBasketItem> BasketItems { get; set; }

       
        public decimal TotalAmount
        {
            get { return BasketItems.Sum(x => x.Quantity * x.MenuItem.Price); }
            set { }
        }
    }
}
