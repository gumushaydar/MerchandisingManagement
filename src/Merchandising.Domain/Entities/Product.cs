using Merchandising.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchandising.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
