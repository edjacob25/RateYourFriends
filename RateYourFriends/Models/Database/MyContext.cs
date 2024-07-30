using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RateYourFriends.Models.Database
{
    public class MyContext : IdentityDbContext<Person>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Ranking> Rankings { get; set; }

        public MyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>().ToTable("Question");

            modelBuilder.Entity<Question>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Question>()
                .HasOne<Person>(m => m.Owner)
                .WithMany(m => m.OwnedQuestions)
                .HasForeignKey(m => m.OwnerId);

            modelBuilder.Entity<Ranking>().ToTable("Ranking");

            modelBuilder.Entity<Ranking>()
                .HasKey(m => new { m.QuestionId, m.GiverId, m.ReceiverId });

            modelBuilder.Entity<Ranking>()
                .HasIndex(m => new { m.QuestionId, m.ReceiverId });

            modelBuilder.Entity<Ranking>().HasIndex(m => m.QuestionId);

            modelBuilder.Entity<Ranking>()
                .HasOne<Question>(m => m.Question)
                .WithMany(m => m.Ranks)
                .HasForeignKey(m => m.QuestionId);

            modelBuilder.Entity<Ranking>()
                .HasOne<Person>(m => m.Giver)
                .WithMany(m => m.Ranked)
                .HasForeignKey(m => m.GiverId);

            modelBuilder.Entity<Ranking>()
                .HasOne<Person>(m => m.Receiver)
                .WithMany(m => m.RankedIn)
                .HasForeignKey(m => m.ReceiverId);

            modelBuilder.Entity<PersonQuestion>().ToTable("PersonQuestion");

            modelBuilder.Entity<PersonQuestion>()
                .HasKey(m => new { GroupId = m.QuestionId, m.PersonId });

            modelBuilder.Entity<PersonQuestion>()
                .HasIndex(m => m.QuestionId);

            modelBuilder.Entity<PersonQuestion>()
                .HasOne<Person>(m => m.Person)
                .WithMany(m => m.Questions)
                .HasForeignKey(m => m.PersonId);

            modelBuilder.Entity<PersonQuestion>()
                .HasOne<Question>(m => m.Question)
                .WithMany(m => m.Participants)
                .HasForeignKey(m => m.QuestionId);
        }
    }
}