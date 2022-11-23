using System.ComponentModel.DataAnnotations;

namespace FlatworldConnectWeb.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public long Mobile { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
