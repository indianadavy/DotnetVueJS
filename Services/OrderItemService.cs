using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shipbob.Models;

namespace shipbob.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ShipBobContext _context;

        public OrderItemService(ShipBobContext context)
        {
            _context = context;
        }

        #region Orders
        public async Task<IEnumerable<OrderItem>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.ToArrayAsync();

            return orders;
        }
        public async Task<OrderItem> GetOrderAsync(int OrderID)
        {
            var order = await _context.Orders.SingleAsync(t => t.ID == OrderID);

            return order;
        }
        public async Task<IEnumerable<OrderItem>> GetOrdersFor(int userID)
        {
            var orders = await _context.Orders.Where(u => u.UserID == userID).ToArrayAsync();
            
            return orders;
        }
        public async Task<int> CreateOrder(OrderItem order)
        {
            await _context.Orders.AddAsync(order);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> UpdateOrder(OrderItem order)
        {
            var orderToUpdate = await _context.Orders.SingleOrDefaultAsync(s => s.ID == order.ID);
            _context.Entry(orderToUpdate).State = EntityState.Modified;
            orderToUpdate.Name = order.Name;
            orderToUpdate.StreetAddress = order.StreetAddress;
            orderToUpdate.City = order.City;
            orderToUpdate.State = order.State;
            orderToUpdate.ZipCode = order.ZipCode;
            orderToUpdate.TrackingID = order.TrackingID;
            orderToUpdate.UserID = order.UserID;

            return await _context.SaveChangesAsync();
        }
            // var oldOrder = _context.Orders.SingleOrDefaultAsync(o => o.ID == order.ID).;
            // if (oldOrder != null)
            // {
            //     oldOrder
            // }
            // await _context.Orders.Update();
        #endregion

        #region Users
        public async Task<IEnumerable<UserItem>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToArrayAsync();

            return users;
        }
        public async Task<int> CreateUser(UserItem user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();
        }
        #endregion
    }
}
