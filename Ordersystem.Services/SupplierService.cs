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

    /// <summary>
    /// The `SupplierService` class demonstrates the use of CRUD (Create, Read, Update, Delete) operations.
    /// It implements the `ISupplierService` interface and provides the necessary methods for working with suppliers.
    /// </summary>
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves all suppliers from the database.
        /// </summary>
        /// <returns>A list of Supplier objects representing all suppliers in the database.</returns>
        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        /// <summary>
        /// Retrieves a supplier from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the supplier to retrieve.</param>
        /// <returns>The Supplier object corresponding to the specified ID, or null if not found.</returns>
        public Supplier? GetSupplierByID(int id)
        {
            return _context.Suppliers.Where(c => c.SupplierID == id).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new supplier in the database.
        /// </summary>
        /// <param name="supplier">The Supplier object representing the supplier to create.</param>
        /// <returns>The Supplier object representing the created supplier.</returns>
        public Supplier Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier;
        }

        /// <summary>
        /// Updates an existing supplier in the database with the provided data.
        /// </summary>
        /// <param name="id">The ID of the supplier to update.</param>
        /// <param name="newSupplier">The Supplier object containing the updated data for the supplier.</param>
        /// <returns>The Supplier object representing the updated supplier, or null if the supplier with the specified ID is not found.</returns>
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

        /// <summary>
        /// Deletes a supplier from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the supplier to delete.</param>
        /// <returns>True if the supplier was successfully deleted, false otherwise.</returns>
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
