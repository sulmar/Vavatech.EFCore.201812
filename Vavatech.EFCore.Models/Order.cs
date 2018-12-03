using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.EFCore.Models
{
    public class Order : Base
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
