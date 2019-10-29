using DAL.Models;
using System;
using System.Threading.Tasks;

namespace DAL.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Contractor> Contractors { get; }
        IRepository<InvoiceHeader> InvoiceHeaders { get; }
        IRepository<InvoicePosition> InvoicePositions { get; }
        IRepository<Product> Products { get; }
        IRepository<Vat> Vats { get; }
        IRepository<Warehouse> Warehouses { get; }
        IRepository<WarehouseDocumentHeader> WarehouseDocumentHeaders { get; }
        IRepository<WarehouseDocumentPosition> WarehouseDocumentPositions { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
