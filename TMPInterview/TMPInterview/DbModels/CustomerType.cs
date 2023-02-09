using System;
using System.Collections.Generic;

namespace TMPInterview.DbModels
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customers = new HashSet<Customer>();
        }

        public short Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
