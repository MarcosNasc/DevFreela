using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public string FreelancertName { get; set; }
        public decimal TotalCost { get; set; }

        public ProjectItemViewModel(int id, string title, string clientName, string freelancertName, decimal totalCost)
        {
            Id = id;
            Title = title;
            ClientName = clientName;
            FreelancertName = freelancertName;
            TotalCost = totalCost;
        }
    }
}
