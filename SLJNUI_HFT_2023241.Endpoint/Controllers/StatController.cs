using Microsoft.AspNetCore.Mvc;
using SLJNUI_HFT_2023241.Logic;
using SLJNUI_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace SLJNUI_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICourierLogic logic;

        public StatController(ICourierLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{input}")]
        public double AvgCourierAge(string input)
        {
            return this.logic.AvgCourierAge(input);
        }
        [HttpGet("{value}")]
        public IQueryable<Courier> RestaurantWithExactId(int value)
        {
            return this.logic.RestaurantWithExactId(value);
        }
        [HttpGet("{name}")]
        public IQueryable<string> ListByRestaurantName(string name)
        {
            return this.logic.ListByRestaurantName(name);
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> FoodsWithSumFoodPrice()
        {
            return this.logic.FoodsWithSumFoodPrice();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> RestaurantsWithAvgFoodPrice()
        {
            return this.logic.RestaurantsWithAvgFoodPrice();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> RestaurantsSumStaff()
        {
            return this.logic.RestaurantsSumStaff();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountByFoods()
        {
            return this.logic.CountByFoods();
        }

    }
}
