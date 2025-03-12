namespace DevFreela.API.Entities
{
    public class ProjectCommment : BaseEntity
    {
        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public Project Project { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }

        public ProjectCommment(string content , int idProject , int idUser )
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

    }
}