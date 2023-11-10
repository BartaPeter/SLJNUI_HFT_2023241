using SLJNUI_HFT_2023241.Models;
using System.Linq;

namespace SLJNUI_HFT_2023241.Logic
{
    public interface IRestaurantLogic
    {
        void Create(Restaurant item);
        void Delete(int id);
        Restaurant Read(int id);
        IQueryable<Restaurant> ReadAll();
        void Update(Restaurant item);
    }
}