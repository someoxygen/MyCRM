using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;

namespace MyCRM.Controllers
{
    [Controller]
    [Route("api/[controller]/contact")]
    public class ContactController
    {
        AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            // Logic to retrieve all contacts
            _context.Contacts.ToList();
            return new OkObjectResult(new { message = "Retrieved all contacts" });
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            // Logic to retrieve a contact by ID
            _context.Contacts.Find(id);
            return new OkObjectResult(new { message = $"Retrieved contact with ID {id}" });
        }

        [HttpPost]
        public IActionResult CreateContact([FromBody] object contact)
        {
            // Logic to create a new contact
            if(contact != null)
            {
                var json = contact.ToString();
                var newContact = System.Text.Json.JsonSerializer.Deserialize<MyCRM.Models.Contact>(json);
                if (newContact != null)
                {
                    newContact.CreatedAt = DateTime.Now;
                    newContact.IsActive = true;
                    newContact.IsDeleted = false;
                    _context.Contacts.Add(newContact);
                    _context.SaveChanges();
                    return new OkObjectResult(new { message = "Created new contact", contact = newContact });
                }
                return new BadRequestObjectResult(new { message = "Invalid contact data" });
            }
            return new BadRequestObjectResult(new { message = "Contact is empty" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] object contact)
        {
            // Logic to update an existing contact
            _context.Contacts.Find(id);
            _context.Contacts.Update((MyCRM.Models.Contact)contact);
            _context.SaveChanges();
            return new OkObjectResult(new { message = $"Updated contact with ID {id}" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            // Logic to delete a contact
            _context.Contacts.Find(id);
            _context.Contacts.Remove(new MyCRM.Models.Contact { Id = id });
            return new OkObjectResult(new { message = $"Deleted contact with ID {id}" });
        }
    }
}
