
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuSubs.Controllers
{
    [Route("api/[controller]")]
    public class CusController : Controller 
    {
        private readonly Manager _manager;

        public CusController(Context context)
        {
            _manager = new Manager(context);
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomer()
        {
            
            try
            {
                return Ok(await _manager.GetAllCustomer());
               
            }
            catch (Exception)
            {
                return BadRequest("Nothing in DB");
            }
        }
        // POST api/values
        [HttpPost]
        public async Task<ActionResult> CreateCustomer( Customers customers)
        {
            try
            {
                return Ok(await _manager.AddCustomer(customers));
            }
            catch (Exception)
            {
                return BadRequest("Measurement is null");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var result = _manager.DeleteCustomer(id);
            if (result != null) return Ok(await result);
            return BadRequest("Nothing to delete");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer([FromBody]Customers id)
        {
            var result = _manager.UpdateCustomer(id);
            if (result != null) return Ok(await result);
            return BadRequest("Nothing to update");
        }
    }
}
