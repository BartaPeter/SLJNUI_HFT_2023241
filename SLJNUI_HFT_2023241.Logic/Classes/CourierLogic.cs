using Microsoft.EntityFrameworkCore.Query.Internal;
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
        public IQueryable<string> ListByRestaurantName(string name)
        {
            return this.repository.ReadAll().Where(t => t.restaurants.RestaurantName == name)
                .Select(t => t.CourierName);
        }
        public IEnumerable<KeyValuePair<string,int>> FoodsWithSumFoodPrice()
        {
            return from x in repository.ReadAll().ToList()
                   group x by x.foods.FoodName into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Sum(t => t.foods.FoodPrice));
        }
        public IEnumerable<KeyValuePair<string, double>> RestaurantsWithAvgFoodPrice()
        {
            return from x in repository.ReadAll().ToList()
                   group x by x.restaurants.RestaurantName into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.foods.FoodPrice));
        }
        public IEnumerable<KeyValuePair<string,double>> RestaurantsSumStaff()
        {
            return from y in repository.ReadAll().ToList()
                   group y by y.restaurants.RestaurantName into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Sum(t => t.restaurants.StaffDb));
        }
        public IEnumerable<KeyValuePair<string,int>> CountByFoods()
        {
            return from z in repository.ReadAll()
                   group z by z.foods.FoodName into g
                   select new KeyValuePair<string,int>
                   (g.Key, g.Count());
        }
    }
}
