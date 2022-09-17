using System.Collections.Generic;
using ResturantAPI.Dtos;
using ResturantAPI.Models;

namespace ResturantAPI.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer Get(int Id);
        int Create(CreateCustomerDto dto);
        int Update(UpdateCustomerDto dto);
        void Delete(int Id);
    }
}