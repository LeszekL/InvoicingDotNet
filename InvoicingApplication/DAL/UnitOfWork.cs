using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        protected readonly DbContext context;

        private IRepository<Contractor> contractors;
        public IRepository<Contractor> Contractors
        {
            get
            {
                if (contractors == null)
                {
                    contractors = new Repository<Contractor>(context);
                }
                return contractors;
            }
        }

        private IRepository<InvoiceHeader> invoiceHeaders;
        public IRepository<InvoiceHeader> InvoiceHeaders
        {
            get
            {
                if (invoiceHeaders == null)
                {
                    invoiceHeaders = new Repository<InvoiceHeader>(context);
                }
                return invoiceHeaders;
            }
        }

        private IRepository<InvoicePosition> invoicePositions;
        public IRepository<InvoicePosition> InvoicePositions
        {
            get
            {
                if (invoicePositions == null)
                {
                    invoicePositions = new Repository<InvoicePosition>(context);
                }
                return invoicePositions;
            }
        }


        private IRepository<Product> products;
        public IRepository<Product> Products
        {
            get
            {
                if (products == null)
                {
                    products = new Repository<Product>(context);
                }
                return products;
            }
        }

        private IRepository<Vat> vats;
        public IRepository<Vat> Vats
        {
            get
            {
                if (vats == null)
                {
                    vats = new Repository<Vat>(context);
                }
                return vats;
            }
        }

        private IRepository<Warehouse> warehouses;
        public IRepository<Warehouse> Warehouses
        {
            get
            {
                if (warehouses == null)
                {
                    warehouses = new Repository<Warehouse>(context);
                }
                return warehouses;
            }
        }

        private IRepository<WarehouseDocumentHeader> warehouseDocumentHeaders;
        public IRepository<WarehouseDocumentHeader> WarehouseDocumentHeaders
        {
            get
            {
                if (warehouseDocumentHeaders == null)
                {
                    warehouseDocumentHeaders = new Repository<WarehouseDocumentHeader>(context);
                }
                return warehouseDocumentHeaders;
            }
        }

        private IRepository<WarehouseDocumentPosition> warehouseDocumentPositions;
        public IRepository<WarehouseDocumentPosition> WarehouseDocumentPositions
        {
            get
            {
                if (warehouseDocumentPositions == null)
                {
                    warehouseDocumentPositions = new Repository<WarehouseDocumentPosition>(context);
                }
                return warehouseDocumentPositions;
            }
        }

        public UnitOfWorkEF(DbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
