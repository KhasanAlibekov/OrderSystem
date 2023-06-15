using Ordersystem.DataAccess;
using Ordersystem.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordersystem.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order? GetOrderByID(int id);
        Order Create(Order order);
        Order Update(int id, Order newOrder);
        bool Delete(int id);
    }

    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context) // Contructor injection
        {
            this._context = context;
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order? GetOrderByID(int id)
        {
            return _context.Orders.Where(c => c.OrderID == id).FirstOrDefault();
        }

        public Order Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

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
