using ApiCrudTasks.Models;
using ApiCrudTasks.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAllUsers()
        {

            List<UserModel> users = await _userRepository.FindAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindUserById(int id)
        {

            UserModel user = await _userRepository.FindUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> InsertUser([FromBody] UserModel userModel)
        {

            UserModel user = await _userRepository.InsertUser(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {

            UserModel updateUser = await _userRepository.UpdateUser(userModel, id);
            return Ok(updateUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {

            bool delete = await _userRepository.DeleteUser(id);
            return Ok(delete);
        }
    }
}
