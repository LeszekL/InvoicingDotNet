using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            InvoicePosition = new HashSet<InvoicePosition>();
            WarehouseDocumentPosition = new HashSet<WarehouseDocumentPosition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<InvoicePosition> InvoicePosition { get; set; }
        public virtual ICollection<WarehouseDocumentPosition> WarehouseDocumentPosition { get; set; }
    }
}
