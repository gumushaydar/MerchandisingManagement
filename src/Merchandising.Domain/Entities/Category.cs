using Merchandising.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchandising.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumStockQuantity { get; set; }

        public IList<Product> Products { get; private set; }
    }
}
