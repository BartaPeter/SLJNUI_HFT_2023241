using SLJNUI_HFT_2023241.Logic;
using SLJNUI_HFT_2023241.Models;
using SLJNUI_HFT_2023241.Repository;
using System;
using System.Linq;

namespace SLJNUI_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RestaurantDbContext rest = new RestaurantDbContext();
            CourierRepository repo = new CourierRepository(rest);
            CourierLogic restaurantlogic = new CourierLogic(repo);
            rest.Couriers.ToList().ForEach(t => Console.WriteLine(t.CourierId+"\t"+t.restaurants.RestaurantName+"\t"+t.foods.FoodName));
            Console.WriteLine();
            var teszt = restaurantlogic.RestaurantsWithExactName("McDonald's");
        }
    }
}
