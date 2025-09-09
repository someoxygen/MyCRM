namespace MyCRM.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Company { get; set; }
        public string? Notes { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public User? User { get; set; }
        public Contact? Contact { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
