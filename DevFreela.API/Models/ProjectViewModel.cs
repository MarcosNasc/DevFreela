using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public string FreelancertName { get; set; }
        public decimal TotalCost { get; set; }

        public ProjectViewModel(int id, string title, string clientName, string freelancertName, decimal totalCost)
        {
            Id = id;
            Title = title;
            ClientName = clientName;
            FreelancertName = freelancertName;
            TotalCost = totalCost;
        }

        public static ProjectViewModel FromEntity(Project project)
        {
            return new ProjectViewModel(project.Id, project.Title, project.Client.FullName, project.Freelancer.FullName, project.TotalCost);
        }
    }
}
