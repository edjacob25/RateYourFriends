using Microsoft.AspNetCore.Identity;

namespace RateYourFriends.Models.Database
{
    public class Person : IdentityUser
    {
        public string? FacebookId { get; set; }

        public string Username { get; set; }

        public List<Question> OwnedQuestions { get; set; }
        public List<PersonQuestion> Questions { get; set; }
        public List<Ranking> RankedIn { get; set; }
        public List<Ranking> Ranked { get; set; }
    }
}