namespace Vavatech.EFCore.Models
{
    public class Product : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
