﻿namespace DevFreela.API.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectCommment> Comments { get; private set; }

        protected Project(){ }

        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectCommment>();
        }

        public void Cancel()
        {
            if(Status == ProjectStatusEnum.InProgress || Status ==  ProjectStatusEnum.Suspended)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Complete()
        {
            if (Status == ProjectStatusEnum.PaymentPending || Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Completed;
                CompletedAt = DateTime.Now;
            }
        }

        public void SetPaymentPending()
        {
            if (Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.PaymentPending;
            }
        }

        public void Update(string title , string description , decimal totalCost )
        {
            Title= title;
            Description= description;
            TotalCost = totalCost;
        }
    }
}
