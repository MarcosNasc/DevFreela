namespace DevFreela.API.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
