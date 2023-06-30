using Ordersystem.DataAccess;
using Ordersystem.DataObjects;

namespace Ordersystem.Services
{
    // Interface to define the contract for the OrderService class
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order? GetOrderByID(int id);
        Order Create(Order order);
        Order Update(int id, Order newOrder);
        bool Delete(int id);
    }

    /// <summary>
    /// The `OrderService` class demonstrates the use of CRUD (Create, Read, Update, Delete)
    /// operations.
    /// It implements the `IOrderService` interface and provides the necessary methods for working
    /// with orders.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves all orders from the database.
        /// </summary>
        /// <returns>A list of Order objects representing all orders in the database.</returns>
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        /// <summary>
        /// Retrieves an order from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the order to retrieve.</param>
        /// <returns>The Order object corresponding to the specified ID, or null if not found.</returns>
        public Order? GetOrderByID(int id)
        {
            return _context.Orders.Where(c => c.OrderID == id).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new order in the database.
        /// </summary>
        /// <param name="order">The Order object representing the order to create.</param>
        /// <returns>The Order object representing the created order.</returns>
        public Order Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        /// <summary>
        /// Updates an existing order in the database with the provided data.
        /// </summary>
        /// <param name="id">The ID of the order to update.</param>
        /// <param name="newOrder">The Order object containing the updated data for the order.</param>
        /// <returns>The Order object representing the updated order, or null if the order with the specified ID is not found.</returns>
        public Order Update(int id, Order newOrder)
        {
            var orderToUpdate = _context.Orders.Where(c => c.OrderID == id).FirstOrDefault();

            if (orderToUpdate != null)
            {
                orderToUpdate.OrderCount = newOrder.OrderCount;
                orderToUpdate.OrderDate = DateTime.Now;

                _context.Update(orderToUpdate);
                _context.SaveChanges();

                return orderToUpdate;
            }
            return null;
        }

        /// <summary>
        /// Deletes an order from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the order to delete.</param>
        /// <returns>True if the order was successfully deleted, false otherwise.</returns>
        public bool Delete(int id)
        {
            var result = _context.Orders.ToList().FirstOrDefault(c => c.OrderID == id, null);
            if (result != null)
            {
                _context.Orders.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
