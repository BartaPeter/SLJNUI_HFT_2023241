using Moq;
using NUnit.Framework;
using SLJNUI_HFT_2023241.Logic;
using SLJNUI_HFT_2023241.Models;
using SLJNUI_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SLJNUI_HFT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        CourierLogic courierlogic;
        Mock<IRepository<Courier>> mockCourierRepository;
        [SetUp]
        public void Init()
        {
            Restaurant fakeRestaurant1 = new Restaurant()
            {
                RestaurantId = 1,
                RestaurantName = "TestRestaurant1",
                RestaurantOpen = true,
                StaffDb = 200
            };
            Restaurant fakeRestaurant2 = new Restaurant()
            {
                RestaurantId = 2,
                RestaurantName = "TestRestaurant2",
                RestaurantOpen = false,
                StaffDb = 300
            };
            Restaurant fakeRestaurant3 = new Restaurant()
            {
                RestaurantId = 3,
                RestaurantName = "TestRestaurant3",
                RestaurantOpen = true,
                StaffDb = 250
            };
            Restaurant fakeRestaurant4 = new Restaurant()
            { 
                RestaurantId = 4,
                RestaurantName = "TestRestaurant4",
                RestaurantOpen = true,
                StaffDb = 220
            };
            Restaurant fakeRestaurant5 = new Restaurant()
            {
                RestaurantId = 5,
                RestaurantName = "TestRestaurant5",
                RestaurantOpen = false,
                StaffDb = 150
            };
            Restaurant fakeRestaurant6 = new Restaurant()
            {
                RestaurantId = 6,
                RestaurantName = "TestRestaurant6",
                RestaurantOpen = true,
                StaffDb = 120
            };
            Restaurant fakeRestaurant7 = new Restaurant()
            {
                RestaurantId = 7,
                RestaurantName = "TestRestaurant7",
                RestaurantOpen = true,
                StaffDb = 30
            };
            Restaurant fakeRestaurant8 = new Restaurant()
            {
                RestaurantId = 8,
                RestaurantName = "TestRestaurant8",
                RestaurantOpen = false,
                StaffDb = 50
            };
            Restaurant fakeRestaurant9 = new Restaurant()
            {
                RestaurantId = 9,
                RestaurantName = "TestRestaurant9",
                RestaurantOpen = true,
                StaffDb = 90
            };
            Restaurant fakeRestaurant10 = new Restaurant()
            {
                RestaurantId = 10,
                RestaurantName = "TestRestaurant10",
                RestaurantOpen = false,
                StaffDb = 40
            };
            Food fakefood1 = new Food()
            {
                FoodId = 1,
                FoodName = "TestFood1",
                FoodType = "Warm",
                FoodPrice = 1000,
            };
            Food fakefood2 = new Food()
            {
                FoodId = 2,
                FoodName = "TestFood2",
                FoodType = "Warm",
                FoodPrice = 2500,
            };
            Food fakefood3 = new Food()
            {
                FoodId = 3,
                FoodName = "TestFood3",
                FoodType = "Cold",
                FoodPrice = 4000,
            };
            Food fakefood4 = new Food()
            {
                FoodId = 4,
                FoodName = "TestFood4",
                FoodType = "Warm",
                FoodPrice = 9500,
            };
            Food fakefood5 = new Food()
            {
                FoodId = 5,
                FoodName = "TestFood5",
                FoodType = "Warm",
                FoodPrice = 5500,
            };
            Food fakefood6 = new Food()
            {
                FoodId = 6,
                FoodName = "TestFood6",
                FoodType = "Warm",
                FoodPrice = 1650,
            };
            Food fakefood7 = new Food()
            {
                FoodId = 7,
                FoodName = "TestFood7",
                FoodType = "Cold",
                FoodPrice = 1350,
            };
            Food fakefood8 = new Food()
            {
                FoodId = 8,
                FoodName = "TestFood8",
                FoodType = "Warm",
                FoodPrice = 990,
            };
            Food fakefood9 = new Food()
            {
                FoodId = 9,
                FoodName = "TestFood9",
                FoodType = "Warm",
                FoodPrice = 3490,
            };
            Food fakefood10 = new Food()
            {
                FoodId = 10,
                FoodName = "TestFood10",
                FoodType = "Warm",
                FoodPrice = 1490,
            };

            var input = new List<Courier>(){
            new Courier()
            {
                CourierId = 1,
                CourierName = "Test1",
                CourierAge = 18,
                restaurants = fakeRestaurant1,
                foods = fakefood1
            },
            new Courier()
            {
                CourierId = 2,
                CourierName = "Test2",
                CourierAge = 40,
                restaurants = fakeRestaurant1,
                foods = fakefood2
            },
            new Courier()
            {
                CourierId = 3,
                CourierName = "Test3",
                CourierAge = 50,
                restaurants = fakeRestaurant2,
                foods = fakefood3
            },
            new Courier()
            {
                CourierId = 4,
                CourierName = "Test4",
                CourierAge = 20,
                restaurants = fakeRestaurant4,
                foods = fakefood4
            },
            new Courier()
            {
                CourierId = 5,
                CourierName = "Test5",
                CourierAge = 55,
                restaurants = fakeRestaurant5,
                foods = fakefood5
            },
            new Courier()
            {
                CourierId = 6,
                CourierName = "Test6",
                CourierAge = 40,
                restaurants = fakeRestaurant5,
                foods = fakefood6
            },
            new Courier()
            {
                CourierId = 7,
                CourierName = "Test7",
                CourierAge = 19,
                restaurants = fakeRestaurant3,
                foods = fakefood7
            },
            new Courier()
            {
                CourierId = 8,
                CourierName = "Test8",
                CourierAge = 28,
                restaurants = fakeRestaurant8,
                foods = fakefood8
            },
            new Courier()
            {
                CourierId = 9,
                CourierName = "Test9",
                CourierAge = 21,
                restaurants = fakeRestaurant9,
                foods = fakefood9
            },
            new Courier()
            {
                CourierId = 10,
                CourierName = "Test10",
                CourierAge = 50,
                restaurants = fakeRestaurant10,
                foods = fakefood10
            },
        };
            mockCourierRepository = new Mock<IRepository<Courier>>();
            IQueryable<Courier> CourierQueryable = input.AsQueryable();
            mockCourierRepository.Setup(m => m.ReadAll()).Returns(CourierQueryable);
            courierlogic = new CourierLogic(mockCourierRepository.Object);
        }

        [Test]
        public void MovieCreatewithCorrectTest()
        {
            var sample = new Courier() { CourierId = 1, CourierName = "Zoli", CourierAge = 18, RestaurantId = 10, FoodId = 9 };
            //ACT
            courierlogic.Create(sample);
            //ASSERT
            mockCourierRepository.Verify(
            m => m.Create(sample),
            Times.Once);
        }
        [Test]
        public void MovieCreatewithIncorrectTest()
        {
            var sample = new Courier() { CourierId = 1, CourierName = "Zoli", CourierAge = 15, RestaurantId = 10, FoodId = 9 };
            try
            {
                courierlogic.Create(sample);
            }
            catch 
            {

            }
            mockCourierRepository.Verify(t=>t.Create(sample), Times.Never);
        }
        [Test]
        public void ExceptionTest()
        {
            var sample = new Courier() { CourierId = 1, CourierName = "Zoli", CourierAge = 15, RestaurantId = 10, FoodId = 9 };
            Assert.That(() => courierlogic.Create(sample), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void AvgCourierAgeTester()
        {
            double answer = courierlogic.AvgCourierAge("TestRestaurant1");
            Assert.That(answer,Is.EqualTo(29));

        }
    }

        

}



