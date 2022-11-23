using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FlatworldConnectWeb.Models
{
    [Keyless]
    public class CreateProject
    {
        public SelectListItem[] CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectListItem[] ManagerName { get; set; }
    }
}
