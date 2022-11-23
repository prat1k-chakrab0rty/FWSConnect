using System.ComponentModel.DataAnnotations;

namespace FlatworldConnectWeb.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? ManagerId { get; set; }
        [Required]
        public string? CustomerId { get; set; }
        [Required]
        public string? JobTitle { get; set; }
        [Required]
        public string? SkillSet { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public int NoOfMonths { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int NoOfResources { get; set; }
    }
}
