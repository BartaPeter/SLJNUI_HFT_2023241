﻿using Microsoft.AspNetCore.Mvc;
using SLJNUI_HFT_2023241.Logic;
using SLJNUI_HFT_2023241.Models;
using System.Collections.Generic;

namespace SLJNUI_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        IFoodLogic logic;

        public FoodController(IFoodLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Food> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Food Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Food value)
        {
            this.logic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] Food value)
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
