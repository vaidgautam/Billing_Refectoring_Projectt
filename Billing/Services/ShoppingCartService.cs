using Billing.Model;
using Billing.Repositories;
using Billing.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        #region "Global Variable"        
        private readonly IBookRepository _bookRepository;
        #endregion

        public ShoppingCartService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        #region "Method"
        /// <summary>
        /// Return calculate Total price
        /// </summary>
        /// <param name="cart"></param>
        /// <returns>totalPrice</returns>
        public decimal CalculateTotalPrice(ShoppingCart cart)
        {
            decimal totalPrice = 0m;

            var discounts = _bookRepository.GetAllDiscounts();

            while (cart.Items.Any())
            {
                var distinctBooks = cart.Items.Select(item => item.BookId).Distinct().ToList();

                decimal discount = 0m;
                foreach (var d in discounts.OrderByDescending(d => d.NumberOfBooks))
                {
                    var applicableBooks = distinctBooks.Take(d.NumberOfBooks).ToList();
                    if (applicableBooks.Count == d.NumberOfBooks)
                    {
                        discount = d.Percentage;
                        break;
                    }
                }

                var priceBeforeDiscount = distinctBooks.Count * 8m;
                totalPrice += priceBeforeDiscount - (priceBeforeDiscount * discount);

                foreach (var bookId in distinctBooks)
                {
                    var item = cart.Items.First(i => i.BookId == bookId);
                    item.Quantity--;
                    if (item.Quantity == 0)
                    {
                        cart.Items.Remove(item);
                    }
                }
            }

            return totalPrice;
        }
        #endregion
    }
}
