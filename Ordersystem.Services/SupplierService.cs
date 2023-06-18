using Ordersystem.DataAccess;
using Ordersystem.DataObjects;

namespace Ordersystem.Services
{
    // Interface to define the contract for the SupplierService class
    public interface ISupplierService
    {
        List<Supplier> GetAllSuppliers();
        Supplier? GetSupplierByID(int id);
        Supplier Create(Supplier supplier);
        Supplier Update(int id, Supplier newSupplier);
        bool Delete(int id);
    }

    //  The `SupplierService` class demonstrates the use of CRUD (Create, Read, Update, Delete) operations.
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier? GetSupplierByID(int id)
        {
            return _context.Suppliers.Where(c => c.SupplierID == id).FirstOrDefault();
        }

        public Supplier Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier;
        }

        public Supplier Update(int id, Supplier newSupplier)
        {
            var supplierToUpdate = _context.Suppliers.Where(c => c.SupplierID == id).FirstOrDefault();

            if (supplierToUpdate != null)
            {
                supplierToUpdate.SupplierName = newSupplier.SupplierName;
                supplierToUpdate.VATNumber = newSupplier.VATNumber;
                supplierToUpdate.Address = newSupplier.Address;
                supplierToUpdate.City = newSupplier.City;
                supplierToUpdate.PostalCode = newSupplier.PostalCode;
                supplierToUpdate.Country = newSupplier.Country;
                supplierToUpdate.Phone = newSupplier.Phone;
                supplierToUpdate.Email = newSupplier.Email;

                _context.Update(supplierToUpdate);
                _context.SaveChanges();

                return supplierToUpdate;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var result = _context.Suppliers.ToList().FirstOrDefault(c => c.SupplierID == id, null);
            if (result != null)
            {
                _context.Suppliers.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
