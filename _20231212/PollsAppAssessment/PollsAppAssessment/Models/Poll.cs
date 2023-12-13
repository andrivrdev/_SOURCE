using PollsAppAssessment.Data;

namespace PollsAppAssessment.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public bool AddOtherAnswerOption { get; set; }
        public bool AddNoneOfTheAboveAnswerOption { get; set; }
        public List<PollDetail> PollDetail { get; set; }
    }
}
