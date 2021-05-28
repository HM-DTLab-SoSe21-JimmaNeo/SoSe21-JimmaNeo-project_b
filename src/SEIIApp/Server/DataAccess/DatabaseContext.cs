using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.Domain;
namespace SEIIApp.Server.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AvatarItem> AvatarItems { get; set; }
        public DbSet<CorrectQuestion> CorrectQuestions { get; set; }
    }
}
