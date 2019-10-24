using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Vat
    {
        public Vat()
        {
            InvoicePosition = new HashSet<InvoicePosition>();
        }

        public int Id { get; set; }
        public decimal PayRate { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InvoicePosition> InvoicePosition { get; set; }
    }
}
