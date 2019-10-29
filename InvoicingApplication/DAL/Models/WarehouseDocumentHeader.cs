using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class WarehouseDocumentHeader
    {
        public WarehouseDocumentHeader()
        {
            WarehouseDocumentPosition = new HashSet<WarehouseDocumentPosition>();
        }

        public int Id { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public int? IdIssuer { get; set; }
        public int? IdContractor { get; set; }
        public int IdWarehouse { get; set; }

        public virtual Contractor IdContractorNavigation { get; set; }
        public virtual Contractor IdIssuerNavigation { get; set; }
        public virtual Warehouse IdWarehouseNavigation { get; set; }
        public virtual ICollection<WarehouseDocumentPosition> WarehouseDocumentPosition { get; set; }
    }
}
