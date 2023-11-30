using Microsoft.AspNetCore.Mvc;
using SLJNUI_HFT_2023241.Logic;
using SLJNUI_HFT_2023241.Models;
using System.Collections.Generic;

namespace SLJNUI_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        IRestaurantLogic logic;

        public RestaurantController(IRestaurantLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Restaurant> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Restaurant Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Restaurant value)
        {
            this.logic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] Restaurant value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
