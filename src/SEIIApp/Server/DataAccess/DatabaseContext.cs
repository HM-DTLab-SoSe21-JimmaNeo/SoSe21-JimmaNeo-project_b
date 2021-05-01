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

        //TODO: Lessons ist ja über Courses definiert, aber wenn ich nur eine bestimmte Lesson muss ich sie hier auch definieren.
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
