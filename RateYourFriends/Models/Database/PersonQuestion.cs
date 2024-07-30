namespace RateYourFriends.Models.Database
{
    public class PersonQuestion
    {
        public string PersonId { get; set; }
        public long QuestionId { get; set; }

        public float? AveragePosition { get; set; }

        public Person Person { get; set; }
        public Question Question { get; set; }
    }
}