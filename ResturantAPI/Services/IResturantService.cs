using System.Collections.Generic;
using ResturantAPI.Dtos;
using ResturantAPI.Models;

namespace ResturantAPI.Services
{
    public interface IResturantService
    {
        List<Resturant> GetAll();
        Resturant Get(int Id);
        int Create(CreateResturantDto dto);
        int Update(UpdateResturantDto dto);
        void Delete(int Id);
    }
}