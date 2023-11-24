using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SLJNUI_HFT_2023241.Models;
using SLJNUI_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Logic
{
    public class CourierLogic : ICourierLogic
    {
        IRepository<Courier> repository;

        public CourierLogic(IRepository<Courier> repository)
        {
            this.repository = repository;
        }

        public void Create(Courier item)
        {
            if (item.CourierAge >= 18 && item.CourierAge <= 65)
            {
                this.repository.Create(item);
            }
            else
            {
                throw new ArgumentException("Codded age is not suitable for the courier job.");
            }
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Courier Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Courier> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Courier item)
        {
            this.repository.Update(item);
        }

        public double AvgCourierAge(string input)
        {
            return repository.ReadAll().Where(t => t.restaurants.RestaurantName == input).Average(a => a.CourierAge);
        }
        public IQueryable<Courier> RestaurantWithExactId(int value)
        {
            return this.repository.ReadAll().Where(t => t.restaurants.RestaurantId == value);  
        }
        public IEnumerable<RestaurantNewWithFilters> RestaurantsWithExactName(string name)
        {
            return repository.ReadAll().Where(t => t.restaurants.RestaurantName == name)
                .Select(t => new RestaurantNewWithFilters
                {
                    Name = t.restaurants.RestaurantName,
                    StaffDb = t.restaurants.StaffDb,
                    RestaurantOpen = t.restaurants.RestaurantOpen,
                    RestaurantId = t.restaurants.RestaurantId,
                    CourierName = t.CourierName,
                });
        }
        public IEnumerable<CourierDetails> CourierWithExactName(string name)
        {
            return repository.ReadAll().Where(t => t.CourierName == name)
                .Select(t => new CourierDetails
                {
                    Id = t.CourierId,
                    Name= t.CourierName,
                    Age = t.CourierAge,
                    RestaurantName = t.restaurants.RestaurantName,
                });
        }
        public IEnumerable<CourierDetails> CourierWithExactId(int value)
        {
            return repository.ReadAll().Where(t => t.CourierId == value)
                .Select(t => new CourierDetails
                {
                    Id = t.CourierId,
                    Name = t.CourierName,
                    Age = t.CourierAge,
                    RestaurantName = t.restaurants.RestaurantName,
                });
        }
    }
}
