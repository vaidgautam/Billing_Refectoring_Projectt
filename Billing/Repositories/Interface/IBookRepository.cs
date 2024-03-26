using Billing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Repositories
{
    public interface IBookRepository
    {
        List<Discount> GetAllDiscounts();
    }
}
