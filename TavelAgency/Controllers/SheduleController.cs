using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace TavelAgency.Controllers
{
    public class SheduleController : ControllerBase
    {
        private readonly ISheduleService _service;

        public SheduleController(ISheduleService service)
        {
            _service = service;
        }
        [Route("GetAlShedule")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shedules>>> GetAll()
        {
            var shedules = _service.Get();
            return Ok(new { data=shedules });
        }
        [Route("SaveShedule")]
        [HttpPost]
        public async Task<ActionResult> SaveShedule([FromBody] Shedules shedule)
        {


         
                _service.Create(shedule);
                return Ok(new { message = "Successfully Saved Shedule", code = 1 });

            

        }

        [Route("UpdateShedule")]
        [HttpPut]
        public ActionResult UpdateShedule([FromQuery] string id, [FromBody] Shedules shedule)
        {
            var existingshedule = _service.Get(id);

            if (existingshedule == null)
            {
                return Ok(new { message = "Shedule Not Found", code = 0 });
            }

            _service.Update(id, shedule);

            return Ok(new { message = "Successfully Updated Shedule", code = 1, data = shedule });
        }
        [Route("DeleteShedule")]
        [HttpDelete]
        public ActionResult DeleteShedule([FromQuery] string id)
        {
            var booking = _service.GetByShedule(id);
            if(booking == null)
            {
                var shedule = _service.Get(id);

                if (shedule == null)
                {
                    return Ok(new { message = "Shedule Not Found", code = 0 });
                }

                _service.Remove(shedule.Id);

                return Ok(new { message = "Successfully Deleted Shedule", code = 1, data = shedule });
            }
            else
            {
                return Ok(new { message = "Already Existing Bookings For This Shedule", code = 0 });
            }
            
        }

    }
}
