using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class InvoiceHeader
    {
        public InvoiceHeader()
        {
            InvoicePosition = new HashSet<InvoicePosition>();
        }

        public int Id { get; set; }
        public int IdBuyer { get; set; }
        public int IdSeller { get; set; }
        public bool? IsPriceNet { get; set; }
        public bool? IsVatSummed { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Contractor IdBuyerNavigation { get; set; }
        public virtual Contractor IdSellerNavigation { get; set; }
        public virtual ICollection<InvoicePosition> InvoicePosition { get; set; }
    }
}
