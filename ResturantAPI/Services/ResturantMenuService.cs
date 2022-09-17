using System.Collections.Generic;
using System.Linq;
using ResturantAPI.Dtos;
using ResturantAPI.Extensions;
using ResturantAPI.Models;

namespace ResturantAPI.Services
{
    public class ResturantMenuService : IResturantMenuService
    {
        private readonly resturantdbContext _db;

        public ResturantMenuService(resturantdbContext db)
        {
            _db = db;
        }

        public List<Resturantmenu> GetAll()
        {
            var menus = _db.Resturantmenus.ToList();
            return menus;
        }

        public Resturantmenu Get(int Id)
        {
            var menu = _db.Resturantmenus.Find(Id);
            return menu;
        }

        public int Create(CreateResturantMenuDto dto)
        {
            var menu = new Resturantmenu
            {
                MealName = dto.MealName.CapitalizeFirstChar(),
                PriceInNis = dto.PriceInNis,
                PriceInUsd = dto.PriceInNis / 3.5,
                Quantity = dto.Quantity,
                ResturantId = dto.ResturantId
            };
            _db.Resturantmenus.Add(menu);
            _db.SaveChanges();
            return menu.Id;
        }

        public int Update(UpdateResturantMenuDto dto)
        {
            var resturantMenu = _db.Resturantmenus.Find(dto.Id);
            resturantMenu.Id = dto.Id;
            resturantMenu.MealName = dto.MealName.CapitalizeFirstChar();
            resturantMenu.PriceInNis = dto.PriceInNis;
            resturantMenu.PriceInUsd = dto.PriceInNis / 3.5;
            resturantMenu.Quantity = dto.Quantity;
            resturantMenu.ResturantId = dto.ResturantId;
            _db.Resturantmenus.Update(resturantMenu);
            _db.SaveChanges();
            return resturantMenu.Id;
        }

        public void Delete(int Id)
        {
            var resturantMenu = _db.Resturantmenus.Find(Id);
            resturantMenu.Archived = true;
            _db.SaveChanges();
        }
    }
}