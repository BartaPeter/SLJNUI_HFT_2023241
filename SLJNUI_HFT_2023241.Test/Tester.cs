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
            var inputdata = new List<Courier>(){
        new Courier("1#Miller Evans#40#1#9"),
        new Courier("2#Alexander Arnolds#32#4#5"),
        new Courier("3#Renn Daniel#21#4#5"),
        new Courier("4#Tompa Adam#20#3#1"),
        new Courier("5#Amrest Korom#20#9#7"),
        new Courier("6#Marosvari Zoltan#20#8#5"),
        new Courier("7#Papp Oliver#20#6#4"),
        new Courier("8#Michael Smith#20#5#1"),
        new Courier("9#Josh Addams#20#3#3"),
        new Courier("10#George Autumn#20#1#2"),
        }.AsQueryable();
            mockCourierRepository = new Mock<IRepository<Courier>>();
            mockCourierRepository.Setup(m => m.ReadAll()).Returns(inputdata);
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
    }

        

}



