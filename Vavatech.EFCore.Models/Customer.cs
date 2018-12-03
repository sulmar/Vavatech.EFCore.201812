using System;

namespace Vavatech.EFCore.Models
{
    public class Customer : Base
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; }
    }
}
