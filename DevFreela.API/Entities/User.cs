namespace DevFreela.API.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime  BirthDate { get; private set; }
        public bool  Active { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjetcs { get; private set; }
        public List<Project> FreelanceProjetcs { get; private set; }
        public List<ProjectCommment> Commments { get; private set; }

        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;
            Skills = new List<UserSkill>();
            OwnedProjetcs = new List<Project>();
            FreelanceProjetcs = new List<Project>();
        }
    }
}
