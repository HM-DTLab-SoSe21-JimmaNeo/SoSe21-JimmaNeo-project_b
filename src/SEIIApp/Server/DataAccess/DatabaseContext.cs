using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.Domain;

namespace SEIIApp.Server.DataAccess
{
    /// <summary>
    /// Database Context.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AvatarItem> AvatarItems { get; set; }
        public DbSet<EquippedItem> EquippedItems { get; set; }
        public DbSet<CorrectQuestion> CorrectQuestions { get; set; }
        public DbSet<FinishedQuiz> FinishedQuizzes { get; set; }
        public DbSet<FinishedLesson> FinishedLessons { get; set; }
        public DbSet<FinishedCourse> FinishedCourses { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
    }
}
