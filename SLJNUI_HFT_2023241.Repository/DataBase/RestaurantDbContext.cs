using Microsoft.EntityFrameworkCore;
using SLJNUI_HFT_2023241.Models;
using System;
using System.IO;

namespace SLJNUI_HFT_2023241.Repository
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public RestaurantDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                //AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                //                builder
                //                .UseSqlServer(conn);
                builder
                .UseInMemoryDatabase("Restaurants")
                .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courier>(couriers => couriers
            .HasOne(couriers => couriers.restaurants)
            .WithMany(restaurants => restaurants.Courier)
            .HasForeignKey(courier => courier.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade));

            

            modelBuilder.Entity<Courier>(couriers => couriers
           .HasOne(couriers => couriers.foods)
           .WithMany(foods => foods.Courier)
           .HasForeignKey(courier => courier.FoodId)
           .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Restaurant>().HasData(new Restaurant[]
            {
                new Restaurant("McDonald's#145#true#1"),
                new Restaurant("Burger King#112#true#2"),
                new Restaurant("Pizza Hut#90#true#3"),
                new Restaurant("Subway#76#true#4"),
                new Restaurant("Starbucks#68#true#5"),
                new Restaurant("KFC#103#true#6"),
                new Restaurant("Taco Bell#88#true#7"),
                new Restaurant("Dunkin' Donuts#55#true#8"),
                new Restaurant("Wendy's#78#true#9"),
                new Restaurant("Freddy Fazbear Pizza#60#true#10"),


            });
            modelBuilder.Entity<Courier>().HasData(new Courier[]
            {
                new Courier("1#Smith Addams#28#1#5"),
                new Courier("2#Johnson Brown#42#5#11"),
                new Courier("3#Williams Clark#31#9#11"),
                new Courier("4#Jones Davis#56#3#2"),
                new Courier("5#Miller Evans#40#1#9"),
                new Courier("6#Wilson Garcia#34#7#5"),
                new Courier("7#Moore Hall#49#4#7"),
                new Courier("8#Taylor Jackson#23#10#14"),
                new Courier("9#Anderson Lewis#37#4#11"),
                new Courier("10#Harris Martin#45#10#12"),
                new Courier("11#Varga Barnabas#27#9#10"),
                new Courier("12#Robinson Miller#33#7#7"),
                new Courier("13#Clark Rodriguez#52#9#9"),
                new Courier("14#Lee Taylor#43#6#9"),
                new Courier("15#Walker White#20#3#6"),
                new Courier("16#Young Adams#61#2#5"),
                new Courier("17#Allen Baker#38#10#7"),
                new Courier("18#Hall Carter#26#4#5"),
                new Courier("19#Hill Collins#30#10#10"),
                new Courier("20#King Cook#27#6#2"),
            });
            modelBuilder.Entity<Food>().HasData(new Food[]
            {
                new Food("1#Spaghetti#Warm#7250"),
                new Food("2#Hamburger#Warm#15000"),
                new Food("3#Caesar Salad#Cold#4500"),
                new Food("4#Sushi#Cold#13500"),
                new Food("5#Chicken Alfredo#Warm#9200"),
                new Food("6#Pizza#Warm#10500"),
                new Food("7#Ice Cream#Cold#2100"),
                new Food("8#Sashimi#Cold#16500"),
                new Food("9#Tacos#Warm#6800"),
                new Food("10#Hot Chocolate#Cold#9500"),
                new Food("11#Salt Cheese#Cold#8560"),
                new Food("12#Starbucks Ice coffee#Cold#1100"),
                new Food("13#Hamburger#Warm#5000"),
                new Food("14#French Fries#Warm#1500"),
                new Food("15#Vegetarian Burger#Warm#3999"),

            });
        }
    }
}
