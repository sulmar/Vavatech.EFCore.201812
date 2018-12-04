using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.EFCore.Models
{
    public class OrderDetail : Base
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
