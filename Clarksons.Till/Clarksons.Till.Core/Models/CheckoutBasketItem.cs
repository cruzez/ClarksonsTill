namespace Clarksons.Till.Core.Models
{
    public class CheckoutBasketItem
    {
        public CheckoutBasketItem()
        {
            
        }

        public CheckoutBasketItem(MenuItem menuItem)
        {
            MenuItem = menuItem;
            Quantity = 1;
        }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }   
    }
}