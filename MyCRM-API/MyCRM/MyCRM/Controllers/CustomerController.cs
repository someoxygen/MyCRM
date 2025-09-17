using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;

namespace MyCRM.Controllers
{
    [Controller]
    [Route("api/[controller]/customer")]
    public class CustomerController
    {
        AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            // Logic to retrieve all customers
            _context.Customers.ToList();
            return new OkObjectResult(new { message = "Retrieved all customers" });
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            // Logic to retrieve a customer by ID
            _context.Customers.Find(id);
            return new OkObjectResult(new { message = $"Retrieved customer with ID {id}" });
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] object customer)
        {
            // Logic to create a new customer
            _context.Customers.Add((MyCRM.Models.Customer)customer);
            _context.SaveChanges();
            return new OkObjectResult(new { message = "Created new customer" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] object customer)
        {
            // Logic to update an existing customer
            _context.Customers.Find(id);
            _context.Customers.Update((MyCRM.Models.Customer)customer);
            _context.SaveChanges();
            return new OkObjectResult(new { message = $"Updated customer with ID {id}" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            // Logic to delete a customer
            _context.Customers.Find(id);
            _context.Customers.Remove((MyCRM.Models.Customer)_context.Customers.Find(id)!);
            _context.SaveChanges();
            return new OkObjectResult(new { message = $"Deleted customer with ID {id}" });
        }
    }
}
