using System.Collections.Generic;
using ResturantAPI.Dtos;
using ResturantAPI.Models;

namespace ResturantAPI.Services
{
    public interface ICustomerOrderService
    {
        List<Customerorder> GetAllOrders();
        Customer GetOrderById(int Id);
        int Order(CreateCustomerOrderDto dto);
        int UpdateOrder(UpdateCustomerOrderDto dto);
        void DeleteOrder(int Id);
    }
}