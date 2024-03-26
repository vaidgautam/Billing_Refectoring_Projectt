using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Model
{
    public class ShoppingCartRequestDetails
    {
        public int Book1 { get; set; }
        public int Book2 { get; set; }
        public int Book3 { get; set; }
        public int Book4 { get; set; }
        public int Book5 { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}
