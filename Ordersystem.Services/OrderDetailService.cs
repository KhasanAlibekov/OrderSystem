using Microsoft.EntityFrameworkCore;
using Ordersystem.DataAccess;
using Ordersystem.DataObjects;

namespace Ordersystem.Services
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetAllOrderDetails();
        OrderDetail? GetOrderDetailByID(int id);
        OrderDetail Create(OrderDetail orderDetail);
        OrderDetail Update(int id, OrderDetail orderDetail);
        OrderDetail CreateNewOrderDetail(OrderDetail orderDetail);
        bool Delete(int id);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailService(ApplicationDbContext context) 
        {
            this._context = context;
        }

        public OrderDetail Create(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return orderDetail;
        }

        public OrderDetail CreateNewOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
            return orderDetail;
        }

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

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails.Include(u => u.Order).Include(u => u.Product).ToList();
        }

        public OrderDetail? GetOrderDetailByID(int id)
        {
            return _context.OrderDetails.Where(c => c.OrderDetailID == id).Include(u => u.Order).Include(u => u.Product).FirstOrDefault();
        }

        public OrderDetail Update(int id, OrderDetail orderDetail)
        {
            var orderDetailToUpdate = _context.OrderDetails.Where(c => c.OrderDetailID == id).Include(u => u.Order).Include(u => u.Product).FirstOrDefault();

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
