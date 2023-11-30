using ConsoleTools;
using SLJNUI_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SLJNUI_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Courier")
            {
                Console.Write("Enter Courier Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Courier Age: ");
                int age = int.Parse(Console.ReadLine());
                rest.Post(new Courier() { CourierName = name, CourierAge = age }, "courier");
            }
            else if(entity == "Restaurant")
            {
                Console.Write("Enter Restaurant Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Restaurant Staff Number: ");
                int number = int.Parse(Console.ReadLine());
                rest.Post(new Restaurant() { RestaurantName = name, StaffDb = number }, "api/restaurant");
            }
            else if (entity == "Food")
            {
                Console.Write("Enter Food Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Food Type: ");
                string type = Console.ReadLine();
                Console.Write("Enter Food Price: ");
                int price = int.Parse(Console.ReadLine());
                rest.Post(new Food() { FoodName = name , FoodType = type, FoodPrice = price}, "api/food");
            }
        }
        static void List(string entity)
        {
            if (entity == "Courier")
            {
                List<Courier> couriers = rest.Get<Courier>("courier");
                foreach (var item in couriers)
                {
                    Console.WriteLine(item.CourierId + ": " + item.CourierName + ": " + item.CourierAge);
                }
            }
            else if (entity == "Restaurant")
            {
                List<Restaurant> restaurants = rest.Get<Restaurant>("api/restaurant");
                foreach (var item in restaurants)
                {
                    Console.WriteLine(item.RestaurantId + ": " + item.RestaurantName /*+ ": " + item.RestaurantOpen + ": " + item.StaffDb*/);
                }
            }
            else if (entity == "Food")
            {
                List<Food> foods = rest.Get<Food>("api/food");
                foreach (var item in foods)
                {
                    Console.WriteLine(item.FoodId + ": " + item.FoodName + ": " + item.FoodType + ": " + item.FoodPrice);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Courier")
            {
                Console.Write("Enter Courier's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Courier one = rest.Get<Courier>(id, "courier");
                Console.Write($"New name [old: {one.CourierName}]: ");
                string name = Console.ReadLine();
                one.CourierName = name;
                rest.Put(one, "courier");
            }
 
            else if (entity == "Restaurant")
            {
                Console.Write("Enter Restaurant's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Restaurant one = rest.Get<Restaurant>(id, "api/restaurant");
                Console.Write($"New name [old: {one.RestaurantName}]: ");
                string name = Console.ReadLine();
                one.RestaurantName = name;
                rest.Put(one, "api/restaurant");
            }
            else if (entity == "Food")
            {
                Console.Write("Enter Food's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Food one = rest.Get<Food>(id, "api/food");
                Console.Write($"New name [old: {one.FoodName}]: ");
                string name = Console.ReadLine();
                one.FoodName = name;
                rest.Put(one, "api/food");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Courier")
            {
                Console.Write("Enter Courier's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "courier");
            }
            else if (entity == "Restaurant")
            {
                Console.Write("Enter Restaurant's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "api/restaurant");
            }
            else if (entity == "Food")
            {
                Console.Write("Enter Food's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "api/food");
            }
        }
        static void AvgCourierAgeConsole()
        {
            Console.WriteLine("Enter Restaurant Name:");
            var result = rest.GetSingle<double>($"/Stat/AvgCourierAge/{Console.ReadLine()}");
            Console.WriteLine("Average Courier Age:");
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static void RestaurantWithExactIdConsole()
        {
            Console.WriteLine("Enter Restaurant ID:");
            var result = rest.Get<Courier>($"/Stat/RestaurantWithExactId/{Console.ReadLine()}");
            Console.WriteLine("Courier Names:");
            foreach (var item in result)
            {
                Console.WriteLine(item.CourierName);
            }
            Console.ReadLine();
        }
        static void ListByRestaurantNameConsole()
        {
            Console.WriteLine("Enter Restaurant Name:");
            var result = rest.Get<string>($"/Stat/ListByRestaurantName/{Console.ReadLine()}");
            Console.WriteLine("Courier Names:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void FoodsWithSumFoodPriceConsole()
        {
            var result = rest.Get<KeyValuePair<string, int>>($"Stat/FoodsWithSumFoodPrice");
            foreach (KeyValuePair<string,int> item in result)
            {
                Console.WriteLine(item.Key + ": "+ item.Value);
            }
            Console.ReadLine();
        }
        static void RestaurantsWithAvgFoodPriceConsole()
        {
            var result = rest.Get<KeyValuePair<string, double>>("Stat/RestaurantsWithAvgFoodPrice");
            foreach (KeyValuePair<string, double> item in result)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            Console.ReadLine();
        }
        static void RestaurantsSumStaffConsole()
        {
            var result = rest.Get<KeyValuePair<string, double>>("Stat/RestaurantsSumStaff");
            foreach (KeyValuePair<string, double> item in result)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            Console.ReadLine();
        }
        static void CountByFoodsConsole()
        {
            var result = rest.Get<KeyValuePair<string, int>>("Stat/CountByFoods");
            foreach (KeyValuePair<string, int> item in result)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:49617/", "courier");

            var courierSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Courier"))
                .Add("Create", () => Create("Courier"))
                .Add("Delete", () => Delete("Courier"))
                .Add("Update", () => Update("Courier"))
                .Add("Exit", ConsoleMenu.Close);

            var restaurantSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Restaurant"))
                .Add("Create", () => Create("Restaurant"))
                .Add("Delete", () => Delete("Restaurant"))
                .Add("Update", () => Update("Restaurant"))
                .Add("Exit", ConsoleMenu.Close);

            var foodSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Food"))
                .Add("Create", () => Create("Food"))
                .Add("Delete", () => Delete("Food"))
                .Add("Update", () => Update("Food"))
                .Add("Exit", ConsoleMenu.Close);

            var noncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("AvgCourierAge", () => AvgCourierAgeConsole())
                .Add("RestaurantWithExactId", () => RestaurantWithExactIdConsole())
                .Add("ListByRestaurantName", () => ListByRestaurantNameConsole())
                .Add("FoodsWithSumFoodPrice", () => FoodsWithSumFoodPriceConsole())
                .Add("RestaurantsWithAvgFoodPrice", () => RestaurantsWithAvgFoodPriceConsole())
                .Add("RestaurantsSumStaff", () => RestaurantsSumStaffConsole())
                .Add("CountByFoods", () => CountByFoodsConsole())
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Couriers", () => courierSubMenu.Show())
                .Add("Restaurants", () => restaurantSubMenu.Show())
                .Add("Foods", () => foodSubMenu.Show())
                .Add("Methods", () => noncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
