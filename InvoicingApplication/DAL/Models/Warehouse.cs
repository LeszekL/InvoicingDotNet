using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            WarehouseDocumentHeader = new HashSet<WarehouseDocumentHeader>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdOwner { get; set; }

        public virtual Contractor IdOwnerNavigation { get; set; }
        public virtual ICollection<WarehouseDocumentHeader> WarehouseDocumentHeader { get; set; }
    }
}
