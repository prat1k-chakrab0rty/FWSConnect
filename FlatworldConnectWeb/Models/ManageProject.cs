using System.ComponentModel.DataAnnotations;

namespace FlatworldConnectWeb.Models
{
    public class ManageProject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int ManagerId { get; set; }
       
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public string? Status { get; set; }

    }
}
