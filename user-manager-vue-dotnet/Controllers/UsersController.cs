using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_manager_vue_dotnet.Entities;
using user_manager_vue_dotnet.Models;
using user_manager_vue_dotnet.Services;

namespace user_manager_vue_dotnet
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly UserContext _context;
        private readonly IUserService _userService;

        //public UsersController(UserContext context, IUserService userService)
        //{
        //    _context = context;
        //    _userService = userService;
        //}
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        [AllowAnonymous]
        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAdmin()
        {
            var users = await _userService.GetAllAdmin();
            if (users == null)
            {
                return NotFound("Can't find users");
            }

            return Ok(users);
        }






        // GET all users: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAll();
            if (users == null)
            {
                return NotFound("Can't find users");
            }

            return Ok(users);
        }

        // GET single user: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        // PUT (update) user: api/Users/Update/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update/{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            
            try
            {
                await _userService.UpdateUserAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_userService.UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST (create) user: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_userService.UserExists(user.UserId))
            {
                throw new ArgumentException($"User {user.Name} already exists.");
            }

            await _userService.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        // DELETE user: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                await _userService.DeleteUserAsync(id);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(user);
        }

        // LOGIN user: api/Users/Authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        // POST (seed) users: api/Users/SeedUsers
        [AllowAnonymous]
        [HttpGet("seedusers")]
        public async Task<ActionResult<User>> SeedUsers()
        {
            if (await _userService.CheckForEmptyDb())
            {
                return Ok("User db already seeded");
            }

            if (await _userService.SeedUsers() == 0)
                return NotFound("User db could not be seeded");
            
            Console.WriteLine($"User database seeded");
            return Ok($"User database seeded");
        }
    }
}
