using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;

namespace MyCRM.Controllers
{
    [Controller]
    [Route("api/[controller]/user")]
    public class UserController
    {
        AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            // Logic to retrieve all users
            _context.Users.ToList();
            return new OkObjectResult(new { message = "Retrieved all users" });
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            // Logic to retrieve a user by ID
            _context.Users.Find(id);
            return new OkObjectResult(new { message = $"Retrieved user with ID {id}" });
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] object user)
        {
            // Logic to create a new user
            _context.Users.Add((MyCRM.Models.User)user);
            _context.SaveChanges();
            return new OkObjectResult(new { message = "Created new user" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] object user)
        {
            // Logic to update an existing user
            _context.Users.Find(id);
            _context.Users.Update((MyCRM.Models.User)user);
            _context.SaveChanges();
            return new OkObjectResult(new { message = $"Updated user with ID {id}" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Logic to delete a user
            _context.Users.Find(id);
            _context.Users.Remove((MyCRM.Models.User)_context.Users.Find(id)!);
            _context.SaveChanges();
            return new OkObjectResult(new { message = $"Deleted user with ID {id}" });
        }
    }
}
