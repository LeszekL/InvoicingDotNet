using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Contractor
    {
        public Contractor()
        {
            InvoiceHeaderIdBuyerNavigation = new HashSet<InvoiceHeader>();
            InvoiceHeaderIdSellerNavigation = new HashSet<InvoiceHeader>();
            Warehouse = new HashSet<Warehouse>();
            WarehouseDocumentHeaderIdContractorNavigation = new HashSet<WarehouseDocumentHeader>();
            WarehouseDocumentHeaderIdIssuerNavigation = new HashSet<WarehouseDocumentHeader>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsOwner { get; set; }

        public virtual ICollection<InvoiceHeader> InvoiceHeaderIdBuyerNavigation { get; set; }
        public virtual ICollection<InvoiceHeader> InvoiceHeaderIdSellerNavigation { get; set; }
        public virtual ICollection<Warehouse> Warehouse { get; set; }
        public virtual ICollection<WarehouseDocumentHeader> WarehouseDocumentHeaderIdContractorNavigation { get; set; }
        public virtual ICollection<WarehouseDocumentHeader> WarehouseDocumentHeaderIdIssuerNavigation { get; set; }
    }
}
