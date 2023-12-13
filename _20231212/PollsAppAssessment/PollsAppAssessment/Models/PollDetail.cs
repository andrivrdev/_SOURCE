namespace PollsAppAssessment.Models
{
    public class PollDetail
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public Poll Poll { get; set; }
    }
}
