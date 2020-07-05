using System;
using System.Collections.Generic;
using System.Text;
using Clarksons.Till.Core.Models;

namespace Clarksons.Till.Data
{
    public interface ICheckoutBasketRepository
    {
        CheckoutBasket GetCheckoutBasket(string basketId);
    }
}
