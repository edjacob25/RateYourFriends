using System.Collections.Generic;

namespace RateYourFriends.Models.Database
{
    public class Question
    {
        public long Id { get; set; }
        public required string Text { get; set; }
        public string OwnerId { get; set; }

        public Person Owner { get; set; }
        public List<PersonQuestion> Participants { get; set; }
        public List<Ranking> Ranks { get; set; }
    }
}