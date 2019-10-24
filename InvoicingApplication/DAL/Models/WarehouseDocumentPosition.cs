using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class WarehouseDocumentPosition
    {
        public int Id { get; set; }
        public int IdWarehouseDocumentHeader { get; set; }
        public int Position { get; set; }
        public int? IdProduct { get; set; }
        public decimal? Amount { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? IdInvoicePosition { get; set; }

        public virtual InvoicePosition IdInvoicePositionNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        public virtual WarehouseDocumentHeader IdWarehouseDocumentHeaderNavigation { get; set; }
    }
}
