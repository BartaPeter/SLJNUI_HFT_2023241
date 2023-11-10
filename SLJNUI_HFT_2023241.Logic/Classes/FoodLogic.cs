using SLJNUI_HFT_2023241.Models;
using SLJNUI_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Logic
{
    public class FoodLogic : IFoodLogic, IFoodLogic
    {
        IRepository<Food> repository;

        public FoodLogic(IRepository<Food> repository)
        {
            this.repository = repository;
        }

        public void Create(Food item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Food Read(int id)
        {
            return this.repository.Read(id);
        }

        public IQueryable<Food> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Food item)
        {
            this.repository.Update(item);
        }
    }
}
