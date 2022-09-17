using System.Collections.Generic;
using ResturantAPI.Dtos;
using ResturantAPI.Models;

namespace ResturantAPI.Services
{
    public interface IResturantMenuService
    {
        List<Resturantmenu> GetAll();
        Resturantmenu Get(int Id);
        int Create(CreateResturantMenuDto dto);
        int Update(UpdateResturantMenuDto dto);
        void Delete(int Id);
    }
}