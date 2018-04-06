using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using shipbob.Models;

namespace shipbob.Services
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllOrdersAsync();
        Task<OrderItem> GetOrderAsync(int OrderID);
        Task<IEnumerable<OrderItem>> GetOrdersFor(int userID);
        Task<int> CreateOrder(OrderItem order);
        Task<int> UpdateOrder(OrderItem order);
        Task<IEnumerable<UserItem>> GetAllUsersAsync();
        Task<UserItem> GetUserAsync(int UserID);
        Task<int> CreateUser(UserItem user);

    }
}
