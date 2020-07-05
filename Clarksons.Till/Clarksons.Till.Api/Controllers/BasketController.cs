using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clarksons.Till.Api.Helpers;
using Clarksons.Till.Core.Models;
using Clarksons.Till.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clarksons.Till.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public BasketController(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        [HttpGet]
        public CheckoutBasket Get()
        {
            return GetCheckOutBasket();
        }


        
        [HttpPost]
        public ActionResult<CheckoutBasket> Add([FromBody] int id)
        {
            var menuItem = _menuItemRepository.Get(id);
            if (menuItem == null) return NotFound();

            var checkOutBasket = GetCheckOutBasket();
            if (!checkOutBasket.BasketItems.Any(x => x.MenuItem.Equals(menuItem)))
            {
                var checkoutBasketItem = new CheckoutBasketItem(menuItem);
                checkOutBasket.BasketItems.Add(checkoutBasketItem);
            }
            else
            {
                checkOutBasket.BasketItems.First(x => x.MenuItem == menuItem).Quantity++;
            }
            SaveCheckoutBasket(checkOutBasket);
            return GetCheckOutBasket();
        }

        [HttpPost]
        public ActionResult<CheckoutBasket> Update(BasketUpdateRequest basketUpdateRequest)
        {
            var menuItem = _menuItemRepository.Get(basketUpdateRequest.Id);
            if (menuItem == null) return NotFound();

            var checkOutBasket = GetCheckOutBasket();
            if (basketUpdateRequest.Quantity > 0)
            {
                if (checkOutBasket.BasketItems.Any(x => x.MenuItem.Id == basketUpdateRequest.Id))
                    checkOutBasket.BasketItems.First(x => x.MenuItem.Id == menuItem.Id).Quantity = basketUpdateRequest.Quantity;
                else
                    checkOutBasket.BasketItems.Add(new CheckoutBasketItem(menuItem) {Quantity = basketUpdateRequest.Quantity});

                SaveCheckoutBasket(checkOutBasket);
            }
            else
                DeleteMenuItem(basketUpdateRequest.Id);

            return GetCheckOutBasket();

        }

        

        // DELETE api/<BasketController>/5
        [HttpDelete("{id}")]
        public CheckoutBasket Delete(int id)
        {
            DeleteMenuItem(id);
            return GetCheckOutBasket();
        }


        #region private

        
        private CheckoutBasket GetCheckOutBasket()
        {
            var checkoutBasket = HttpContext.Session.GetObjectFromJson<CheckoutBasket>("CheckoutBasket");
            if (checkoutBasket != null) return checkoutBasket;

            checkoutBasket = new CheckoutBasket();
            HttpContext.Session.SetObjectAsJson("CheckoutBasket", checkoutBasket);
            return checkoutBasket;
        }

        private void SaveCheckoutBasket(CheckoutBasket checkoutBasket)
        {
            HttpContext.Session.SetObjectAsJson("CheckoutBasket", checkoutBasket);
        }

        private void DeleteMenuItem(int id)
        {
            var menuItem = _menuItemRepository.Get(id);
            if (menuItem == null) throw new KeyNotFoundException("MenuItem Not found");
            var checkOutBasket = GetCheckOutBasket();
            if (!checkOutBasket.BasketItems.Any(x => x.MenuItem.Equals(menuItem))) return;
            var checkoutBasketItem = checkOutBasket.BasketItems.First(x => x.MenuItem == menuItem);
            checkOutBasket.BasketItems.Remove(checkoutBasketItem);
            SaveCheckoutBasket(checkOutBasket);
        }
        #endregion
    }
}
