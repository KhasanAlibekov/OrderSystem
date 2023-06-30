using Microsoft.EntityFrameworkCore;
using Ordersystem.DataAccess;
using Ordersystem.DataObjects;

namespace Ordersystem.Services
{
    // Interface to define the contract for the OrderDetailService class
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAllOrderDetails();
        OrderDetail? GetOrderDetailByID(int id);
        OrderDetail Create(OrderDetail orderDetail);
        OrderDetail Update(int id, OrderDetail orderDetail);
        bool Delete(int id);
    }

    /// <summary>
    /// The `OrderDetailService` class demonstrates the use of CRUD (Create, Read, Update, Delete)
    /// operations.
    /// It implements the `IOrderDetailService` interface and provides the necessary methods for
    /// working with order details.
    /// </summary>
    public class OrderDetailService : IOrderDetailService
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailService(ApplicationDbContext context) 
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new order detail in the database.
        /// </summary>
        /// <param name="orderDetail">The OrderDetail object representing the order detail to create.</param>
        /// <returns>The OrderDetail object representing the created order detail.</returns>
        public OrderDetail Create(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return orderDetail;
        }

        /// <summary>
        /// Deletes an order detail from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the order detail to delete.</param>
        /// <returns>True if the order detail was successfully deleted, false otherwise.</returns>
        public bool Delete(int id)
        {
            var result = _context.OrderDetails.ToList().FirstOrDefault(c => c.OrderDetailID == id, null);
            if (result != null)
            {
                _context.OrderDetails.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retrieves all order details from the database.
        /// </summary>
        /// <returns>A list of OrderDetail objects representing all order details in the database.</returns>
        public List<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails.Include(u => u.Order).Include(u => u.Product).ToList();
        }

        /// <summary>
        /// Retrieves an order detail from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the order detail to retrieve.</param>
        /// <returns>The OrderDetail object corresponding to the specified ID, or null if not found.</returns>
        public OrderDetail? GetOrderDetailByID(int id)
        {
            return _context.OrderDetails.Where(c => c.OrderDetailID == id).FirstOrDefault();
        }

        /// <summary>
        /// Updates an existing order detail in the database with the provided data.
        /// </summary>
        /// <param name="id">The ID of the order detail to update.</param>
        /// <param name="orderDetail">The OrderDetail object containing the updated data for the order detail.</param>
        /// <returns>The OrderDetail object representing the updated order detail, or null if the order detail with the specified ID is not found.</returns>
        public OrderDetail Update(int id, OrderDetail orderDetail)
        {
            var orderDetailToUpdate = _context.OrderDetails.Where(c => c.OrderDetailID == id).FirstOrDefault();

            if (orderDetailToUpdate != null)
            {
                // Update only properties that were changed
                orderDetailToUpdate.UnitPrice = orderDetailToUpdate.UnitPrice;
                orderDetailToUpdate.Quantity = orderDetailToUpdate.Quantity;
                _context.Update(orderDetailToUpdate);
                _context.SaveChanges();

                return orderDetailToUpdate;
            }
            return null;
        }
    }
}
