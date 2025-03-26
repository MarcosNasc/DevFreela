using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public string ClientName { get; set; }
        public string FreelancertName { get; set; }
        public decimal TotalCost { get; set; }
        public List<string> Comments { get; set; }

        public ProjectItemViewModel(int id, string title, string description, int idClient, int idFreelancer, string clientName, string freelancertName, decimal totalCost, List<ProjectCommment> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            ClientName = clientName;
            FreelancertName = freelancertName;
            TotalCost = totalCost;
            Comments = comments.Select(c => c.Content).ToList();
        }

        public static ProjectItemViewModel FromEntity(Project project)
        {
            return new ProjectItemViewModel(project.Id, project.Title, project.Description, project.IdClient, project.IdFreelancer, project.Client.FullName, project.Freelancer.FullName, project.TotalCost, project.Comments);
        }
    }
}
