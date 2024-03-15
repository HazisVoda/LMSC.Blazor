using LMSC.API.Models;
using LMSC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMSC.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<User>>> SearchUser(string firstName)
        {
            try
            {
                var result = await userRepository.GetUserByName(firstName);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return (await userRepository.GetUsers()).ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the Database");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await userRepository.GetUser(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the Database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }

                var createdUser = await userRepository.AddUser(user);

                return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserID }, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the Database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            try
            {
                var userToUpdate = await userRepository.GetUser(user.UserID);

                if (userToUpdate == null)
                {
                    return NotFound($"User with ID = {user.UserID} not found");
                }

                return await userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the Database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await userRepository.GetUser(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with ID = {id} not found");
                }

                return await userRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
