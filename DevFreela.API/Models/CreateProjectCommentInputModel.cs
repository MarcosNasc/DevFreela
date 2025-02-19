namespace DevFreela.API.Models
{
    public class CreateProjectCommentInputModel
    {
        public string Content { get; set; }
        public int Idproject { get; set; }
        public int IdUser { get; set; }
    }
}