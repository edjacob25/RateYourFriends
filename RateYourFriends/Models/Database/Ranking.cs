namespace RateYourFriends.Models.Database
{
    public class Ranking
    {
        public long QuestionId { get; set; }
        public string GiverId { get; set; }
        public string ReceiverId { get; set; }
        public int Rank { get; set; }

        public Question Question { get; set; }
        public Person Giver { get; set; }
        public Person Receiver { get; set; }
    }
}