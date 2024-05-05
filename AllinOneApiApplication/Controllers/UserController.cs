using AllinOneApiApplication.Model.UserModel;
using AllinOneApiApplication.Repository.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllinOneApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            UserReposistory userRepository = new UserReposistory();
            List<user> categories = userRepository.UserDetails();

            return Ok(categories);
        }
    }
}
