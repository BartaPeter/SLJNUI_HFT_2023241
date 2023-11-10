﻿using SLJNUI_HFT_2023241.Models;
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
            //rest.Restaurants.ToList().ForEach(restaurant =>
            //{
            //    Console.WriteLine(restaurant.RestaurantId);
            //});
            rest.Foods.ToList().ForEach(t => Console.WriteLine(t.restaurants.RestaurantName+"\t"+t.FoodName+"\t"+t.couriers.CourierName));
        }
    }
}
