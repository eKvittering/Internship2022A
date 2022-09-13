using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuSubs.Controllers
{
    [Route("api/[controller]")]
    public class SubController : Controller
    {
        private readonly Manager _manager;

        public SubController(Context context)
        {
            _manager = new Manager(context);
        }

        [HttpGet]
        public async Task<ActionResult> GetSubscription()
        {

            try
            {
                return Ok(await _manager.GetAllSub());

            }
            catch (Exception)
            {
                return BadRequest("Nothing in DB");
            }
        }
        // POST api/values
        [HttpPost]
        public async Task<ActionResult> CreateSubscription( Subscriptions sub)
        {
            try
            {
                return Ok(await _manager.AddSub(sub));
            }
            catch (Exception)
            {
                return BadRequest("Measurement is null");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubscription(int id)
        {
            var result = _manager.DeleteSub(id);
            if (result != null) return Ok(await result);
            return BadRequest("Nothing to delete");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubscription([FromBody] Subscriptions id)
        {
            var result = _manager.UpdateSub(id);
            if (result != null) return Ok(await result);
            return BadRequest("Nothing to update");
        }
    }
}
