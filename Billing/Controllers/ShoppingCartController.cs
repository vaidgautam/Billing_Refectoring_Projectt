using Billing.Model;
using Billing.Services.Interface;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Billing.Controllers
{
    public class ShoppingCartController : Controller
    {
        #region "Global Variable"
        private readonly IShoppingCartService _shoppingCartService;
        #endregion

        #region "Constructor"        
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        #endregion

        #region "Action Method"        
        [HttpPost]
        public ActionResult CalculateTotalPrice(ShoppingCart cart)
        {            
            var totalPrice = _shoppingCartService.CalculateTotalPrice(cart);            
            return Json(new { TotalPrice = totalPrice });
        }
        #endregion
    }
}
