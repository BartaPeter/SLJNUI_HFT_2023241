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
            modelBuilder.Entity<Food>(foods => foods
            .HasOne(foods => foods.restaurants)
            .WithMany(restaurant => restaurant.Foods)
            .HasForeignKey(foods => foods.FoodId)
            .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Food>(foods => foods
           .HasOne(foods => foods.couriers)
           .WithMany(courier => courier.Foods)
           .HasForeignKey(foods => foods.FoodId)
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
                new Restaurant("Panera Bread#65#true#10"),
                new Restaurant("Domino's Pizza#72#true#11"),
                new Restaurant("Papa John's#47#true#12"),
                new Restaurant("Tim Hortons#96#true#13"),
                new Restaurant("Denny's#85#true#14"),
                new Restaurant("In-N-Out Burger#39#true#15"),
                new Restaurant("Olive Garden#120#true#16"),
                new Restaurant("Chick-fil-A#63#true#17"),
                new Restaurant("Red Lobster#50#true#18"),
                new Restaurant("Applebee's#92#true#19"),
                new Restaurant("Outback Steakhouse#68#true#20"),
                new Restaurant("TGI Fridays#59#true#21"),
                new Restaurant("Cracker Barrel#74#true#22"),
                new Restaurant("Red Robin#45#true#23"),
                new Restaurant("Cheesecake Factory#83#true#24"),
                new Restaurant("Five Guys#57#true#25"),
                new Restaurant("Arby's#66#true#26"),
                new Restaurant("Popeyes#97#true#27"),
                new Restaurant("Sonic Drive-In#54#true#28"),
                new Restaurant("IHOP#70#true#29"),
                new Restaurant("LongHorn Steakhouse#79#true#30"),
                new Restaurant("Jack in the Box#49#true#31"),
                new Restaurant("Culver's#35#true#32"),
                new Restaurant("Buffalo Wild Wings#68#true#33"),
                new Restaurant("Panda Express#92#true#34"),
                new Restaurant("Little Caesars#42#true#35"),
                new Restaurant("Dairy Queen#61#true#36"),
                new Restaurant("Hooters#57#true#37"),
                new Restaurant("Texas Roadhouse#73#true#38"),
                new Restaurant("Golden Corral#120#true#39"),
                new Restaurant("Chili's#68#true#40"),
                new Restaurant("Ruby Tuesday#46#true#41"),
                new Restaurant("Waffle House#65#true#42"),
                new Restaurant("Carrabba's Italian Grill#63#true#43"),
                new Restaurant("Quiznos#28#true#44"),
                new Restaurant("Moe's Southwest Grill#41#true#45"),
                new Restaurant("P.F. Chang's#54#true#46"),
                new Restaurant("Perkins Restaurant & Bakery#37#true#47"),
                new Restaurant("El Pollo Loco#49#true#48"),
                new Restaurant("Fazoli's#29#true#49"),
                new Restaurant("Freddy Fazbear Pizza#60#true#50"),


            });
            modelBuilder.Entity<Courier>().HasData(new Courier[]
            {
                new Courier("1#Smith Addams#28"),
                new Courier("2#Johnson Brown#42"),
                new Courier("3#Williams Clark#31"),
                new Courier("4#Jones Davis#56"),
                new Courier("5#Miller Evans#40"),
                new Courier("6#Wilson Garcia#34"),
                new Courier("7#Moore Hall#49"),
                new Courier("8#Taylor Jackson#23"),
                new Courier("9#Anderson Lewis#37"),
                new Courier("10#Harris Martin#45"),
                new Courier("11#Martinez Martinez#29"),
                new Courier("12#Robinson Miller#33"),
                new Courier("13#Clark Rodriguez#52"),
                new Courier("14#Lee Taylor#43"),
                new Courier("15#Walker White#20"),
                new Courier("16#Young Adams#61"),
                new Courier("17#Allen Baker#38"),
                new Courier("18#Hall Carter#26"),
                new Courier("19#Hill Collins#30"),
                new Courier("20#King Cook#27"),
                new Courier("21#Scott Cox#22"),
                new Courier("22#Green Edwards#47"),
                new Courier("23#Adams Fisher#35"),
                new Courier("24#Baker Gray#24"),
                new Courier("25#Nelson Hayes#54"),
                new Courier("26#Cox Hernandez#59"),
                new Courier("27#Edwards Hill#44"),
                new Courier("28#Fisher Hughes#32"),
                new Courier("29#Perez Jenkins#39"),
                new Courier("30#Bell Johnson#19"),
                new Courier("31#Chavez Jones#50"),
                new Courier("32#Howard Kelly#46"),
                new Courier("33#Hughes Kim#36"),
                new Courier("34#Kirk Lopez#53"),
                new Courier("35#Ward Martin#21"),
                new Courier("36#Gray Martinez#51"),
                new Courier("37#Rivera Moore#58"),
                new Courier("38#Ramos Perez#25"),
                new Courier("39#Wright Reed#41"),
                new Courier("40#Garcia Rivera#60"),
                new Courier("41#Reyes Roberts#57"),
                new Courier("42#Wood Robinson#48"),
                new Courier("43#Foster Rodriguez#55"),
                new Courier("44#Flores Sanchez#63"),
                new Courier("45#Sanchez Smith#62"),
                new Courier("46#Davis Turner#64"),
                new Courier("47#Thomas Walker#18"),
                new Courier("48#Lewis Wright#23"),
                new Courier("49#Young Wilson#28"),
                new Courier("50#Martin Adams#65"),

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
                new Food("10#Greek Salad#Cold#4100"),
                new Food("11#Steak#Warm#17800"),
                new Food("12#Fruit Salad#Cold#3200"),
                new Food("13#Biryani#Warm#14250"),
                new Food("14#Pancakes#Warm#6200"),
                new Food("15#Ceviche#Cold#8600"),
                new Food("16#Lasagna#Warm#9500"),
                new Food("17#Clam Chowder#Warm#7800"),
                new Food("18#Sorbet#Cold#1500"),
                new Food("19#Fish and Chips#Warm#11200"),
                new Food("20#Caprese Salad#Cold#4700"),
                new Food("21#Ramen#Warm#9350"),
                new Food("22#Hot Dog#Warm#3200"),
                new Food("23#Yogurt#Cold#1800"),
                new Food("24#Paella#Warm#12200"),
                new Food("25#Shrimp Cocktail#Cold#6800"),
                new Food("26#Gyros#Cold#5400"),
                new Food("27#Miso Soup#Warm#2650"),
                new Food("28#Coleslaw#Cold#2400"),
                new Food("29#Tofu Stir-Fry#Warm#8700"),
                new Food("30#Fried Rice#Warm#6800"),
                new Food("31#Potato Salad#Cold#2900"),
                new Food("32#Beef Stroganoff#Warm#15800"),
                new Food("33#Mashed Potatoes#Warm#3600"),
                new Food("34#Cobb Salad#Cold#5100"),
                new Food("35#Burrito#Warm#7400"),
                new Food("36#Panna Cotta#Cold#2900"),
                new Food("37#Shawarma#Warm#10500"),
                new Food("38#Tomato Soup#Warm#3150"),
                new Food("39#Cucumber Salad#Cold#2200"),
                new Food("40#Pho#Warm#8950"),
                new Food("41#Chicken Noodle Soup#Warm#4250"),
                new Food("42#Chocolate Cake#Cold#4200"),
                new Food("43#Barbecue Ribs#Warm#13400"),
                new Food("44#Egg Salad#Cold#3400"),
                new Food("45#Sausage and Peppers#Warm#12600"),
                new Food("46#Strawberry Shortcake#Cold#5200"),
                new Food("47#Spicy Tofu#Warm#6850"),
                new Food("48#Lobster Bisque#Warm#14200"),
                new Food("49#Creme Brulee#Cold#4700"),
                new Food("50#Garlic Bread#Warm#1950"),

            });
        }
    }
}
