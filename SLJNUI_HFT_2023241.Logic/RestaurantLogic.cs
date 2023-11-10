using SLJNUI_HFT_2023241.Models;
using SLJNUI_HFT_2023241.Repository;
using System;
using System.Linq;

namespace SLJNUI_HFT_2023241.Logic
{
    public class RestaurantLogic
    {
        IRepository<Restaurant> repository;

        public RestaurantLogic(IRepository<Restaurant> repository)
        {
            this.repository = repository;
        }

        public void Create(Restaurant item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Restaurant Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Restaurant> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Restaurant item)
        {
            this.repository.Update(item);
        }
    }
}
