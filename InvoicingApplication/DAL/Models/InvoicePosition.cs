using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class InvoicePosition
    {
        public InvoicePosition()
        {
            WarehouseDocumentPosition = new HashSet<WarehouseDocumentPosition>();
        }

        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdHeader { get; set; }
        public int IdVat { get; set; }
        public decimal Value { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

        public virtual InvoiceHeader IdHeaderNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        public virtual Vat IdVatNavigation { get; set; }
        public virtual ICollection<WarehouseDocumentPosition> WarehouseDocumentPosition { get; set; }
    }
}
