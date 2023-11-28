using Microsoft.AspNetCore.Mvc;
using SLJNUI_HFT_2023241.Logic;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<CourierController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CourierController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CourierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CourierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
