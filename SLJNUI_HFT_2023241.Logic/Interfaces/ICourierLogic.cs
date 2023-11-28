using SLJNUI_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace SLJNUI_HFT_2023241.Logic
{
    public interface ICourierLogic
    {
        void Create(Courier item);
        void Delete(int id);
        Courier Read(int id);
        IQueryable<Courier> ReadAll();
        void Update(Courier item);
        double AvgCourierAge(string input);
        IQueryable<Courier> RestaurantWithExactId(int value);
        IQueryable<string> ListByRestaurantName(string name);
        IEnumerable<KeyValuePair<string, int>> FoodsWithSumFoodPrice();
        IEnumerable<KeyValuePair<string, double>> RestaurantsWithAvgFoodPrice();
        IEnumerable<KeyValuePair<string, double>> RestaurantsSumStaff();
        IEnumerable<KeyValuePair<string, int>> CountByFoods();
    }
}