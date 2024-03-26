using Billing.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Repositories
{
    public class BookRepository
    {
        /// <summary>
        /// Discount list data by grouping of books
        /// </summary>
        /// <returns></returns>
        public List<Discount> GetAllDiscounts()
        {
            return new List<Discount>
        {
            new Discount { NumberOfBooks = 2, Percentage = 0.05m },
            new Discount { NumberOfBooks = 3, Percentage = 0.10m },
            new Discount { NumberOfBooks = 4, Percentage = 0.20m },
            new Discount { NumberOfBooks = 5, Percentage = 0.25m }
        };
        }


    }
}
