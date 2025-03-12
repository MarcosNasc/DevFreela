namespace DevFreela.API.Entities
{
    public class Skill : BaseEntity
    {
        public string Description { get; private set; }
        public List<UserSkill> UserSkills { get; private set; }

        public Skill(string description)
        {
            Description = description;
        }

    }
}
