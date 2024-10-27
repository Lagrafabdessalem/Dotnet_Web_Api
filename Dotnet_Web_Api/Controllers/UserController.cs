using Dotnet_Web_Api.Data;
using Dotnet_Web_Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _context.users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }



        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.users.ToListAsync());
         
        }


        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            var userId = await _context.users.FindAsync(user.Id);
            if (userId == null)
            {
                return NotFound("User not found");
            }
            userId.Id = user.Id;
            userId.Name = user.Name;
            userId.Email = user.Email;

            await _context.SaveChangesAsync();
            return Ok(await _context.users.ToListAsync());

        }


        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var userId = await _context.users.FindAsync(id);
            if (userId == null)
            {
                return NotFound("User not found");
            }
            _context.users.Remove(userId);
            await _context.SaveChangesAsync();
            return Ok(await _context.users.ToListAsync());
        }


    }
}
