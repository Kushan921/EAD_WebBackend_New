using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TavelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
     
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            var users =  _service.Get();
            return Ok(users);
        }

        [Route("SaveUser")]
        [HttpPost]
        public async Task<ActionResult> SaveUser([FromBody] Users user)
        {
            var user1 = _service.GetByNIC(user.NIC);
            var user2 = _service.GetByEmail(user.Email);

            if(user1!=null)
            {
                return Ok(new { message = "NIC Already Exists", code = 0 });
            }
            else if(user2!=null)
            {
                return Ok(new { message = "Email Already Exists", code = 0 });
            }
            else
            {
                _service.Create(user);
                return Ok(new { message = "Successfully Created User", code = 1 });
            }

            
        }

        [Route("UpdateUser")]
        [HttpPut]
        public ActionResult UpdateUser([FromQuery]string id, [FromBody] Users user)
        {
            var existinguser = _service.Get(id);

            if (existinguser == null)
            {
                return Ok(new { message = "User Not Found", code = 0});
            }

            _service.Update(id, user);

            return Ok(new { message = "Successfully Updated User", code = 1, data=user });
        }
        [Route("DeleteUser")]
        [HttpDelete]
        public ActionResult DeleteUser([FromQuery]string id)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return Ok(new { message = "User Not Found", code = 0 });
            }

            _service.Remove(user.Id);

            return Ok(new { message = "Successfully Deleted User", code = 1, data = user });
        }

        [Route("LoginUser")]
        [HttpGet]
        public ActionResult LoginUser([FromQuery] string email, [FromQuery]string password)
        {
            var user1 = _service.Login(email,password);
          if(user1 == null)
            {
                return Ok(new { message = "Incorrect Credentials or Iactive User", code = 0 });
            }
          else
            {
                return Ok(new { message = "Successfully Login User", code = 1, data = user1 });
            }

           
        }
    }
}
