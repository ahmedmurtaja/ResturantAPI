using System.Collections.Generic;
using System.Linq;
using ResturantAPI.Dtos;
using ResturantAPI.Models;

namespace ResturantAPI.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly resturantdbContext _db;

        public CustomerOrderService(resturantdbContext db)
        {
            _db = db;
        }

        public List<Customerorder> GetAllOrders()
        {
            var customers = _db.Customerorders.ToList();
            return customers;
        }

        public Customer GetOrderById(int Id)
        {
            var customer = _db.Customers.Find(Id);
            return customer;
        }

        public int Order(CreateCustomerOrderDto dto)
        {
            var Check = IsAvailable(dto.MealId);
            var resMenu = _db.Resturantmenus.Find(dto.MealId);
            if (Check)
            {
                var order = new Customerorder
                {
                    MealId = dto.MealId,
                    CustomerId = dto.CustomerId,
                    OrderQuantity = dto.OrderQuantity
                };
                _db.Customerorders.Add(order);
                resMenu.Quantity = resMenu.Quantity - order.OrderQuantity;
                _db.SaveChanges();
                return order.Id;
            }
            else
            {
                return -1;
            }
        }

        public int UpdateOrder(UpdateCustomerOrderDto dto)
        {
            var Check = IsAvailable(dto.MealId);
            var resturantMenu = _db.Resturantmenus.Find(dto.MealId);
            var res = 0;
            if (Check)
            {
                var newQuantity = dto.OrderQuantity;
                var db = _db.Customerorders.Find(dto.Id);
                var oldQuantity = db.OrderQuantity;
                db.Id = dto.Id;
                db.MealId = dto.MealId;
                db.CustomerId = dto.CustomerId;
                db.OrderQuantity = dto.OrderQuantity;
                if (newQuantity > oldQuantity)
                {
                    res = newQuantity - oldQuantity;
                    resturantMenu.Quantity -= res;
                }
                else
                {
                    res = oldQuantity - newQuantity;
                    resturantMenu.Quantity += res;
                }
                _db.Customerorders.Update(db);
                _db.SaveChanges();
                return db.Id;
            }
            else
            {
                return -1;
            }
        }

        public void DeleteOrder(int Id)
        {
            var order = _db.Customerorders.Find(Id);
            var resMenu = _db.Resturantmenus.Find(order.MealId);
            resMenu.Quantity += 1;
            order.Archived = true;
            _db.SaveChanges();
        }

        public bool IsAvailable(int id)
        {
            var db = _db.Resturantmenus.Find(id);
            if (db.Quantity > 0)
                return true;
            else
                return false;
        }

    }
}