using System.Collections.Generic;
using System.Linq;
using ResturantAPI.Dtos;
using ResturantAPI.Extensions;
using ResturantAPI.Models;

namespace ResturantAPI.Services
{
    public class ResturantService : IResturantService
    {
        private readonly resturantdbContext _db;

        public ResturantService(resturantdbContext db)
        {
            _db = db;
        }

        public List<Resturant> GetAll()
        {
            var resturants = _db.Resturants.ToList();
            return resturants;
        }

        public Resturant Get(int Id)
        {
            var resturant = _db.Resturants.Find(Id);
            return resturant;
        }

        public int Create(CreateResturantDto dto)
        {
            var resturant = new Resturant
            {
                Name = dto.Name.CapitalizeFirstChar(),
                PhoneNumber = dto.PhoneNumber
            };
            _db.Resturants.Add(resturant);
            _db.SaveChanges();
            return resturant.Id;
        }

        public int Update(UpdateResturantDto dto)
        {
            var resturant = _db.Resturants.Find(dto.Id);
            resturant.Id = dto.Id;
            resturant.Name = dto.Name.CapitalizeFirstChar();
            resturant.PhoneNumber = dto.PhoneNumber;
            _db.Resturants.Update(resturant);
            _db.SaveChanges();
            return resturant.Id;
        }

        public void Delete(int Id)
        {
            var resturant = _db.Resturants.Find(Id);
            resturant.Archived = true;
            _db.SaveChanges();
        }
    }
}