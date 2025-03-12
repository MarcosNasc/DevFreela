using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public int IdClient { get;  set; }
        public int IdFreelancer { get;  set; }
        public string ClientName { get;  set; }
        public string FreelancertName { get;  set; }
        public decimal TotalCost { get;  set; }
        public List<string> Comments { get;  set; }

        public ProjectViewModel(int id, string title, string description, int idClient, int idFreelancer, string clientName, string freelancertName, decimal totalCost, List<ProjectCommment> comments)
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

        public static ProjectViewModel FromEntity(Project entity)
        {
            return new ProjectViewModel(entity.Id , entity.Title , entity.Description , entity.IdClient , entity.IdFreelancer , entity.client.FullName , entity.Freelancer.FullName , entity.TotalCost , entity.Comments);
        }
    }
}
