using Microsoft.AspNetCore.Mvc;
using SLJNUI_HFT_2023241.Logic;
using SLJNUI_HFT_2023241.Models;
using System.Collections.Generic;

namespace SLJNUI_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        ICourierLogic logic;

        public CourierController(ICourierLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Courier> ReadAll()
        {
            return this.logic.ReadAll();
        }
                
        [HttpGet("{id}")]
        public Courier Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Courier value)
        {
            this.logic.Create(value);
        }
        [HttpPut("{id}")]
        public void Update([FromBody] Courier value)
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
