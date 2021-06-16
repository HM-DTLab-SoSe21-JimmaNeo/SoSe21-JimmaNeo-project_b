using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services {
    /// <summary>
    /// Service for Lessons.
    /// </summary>
    public class LessonService {
        private DatabaseContext DatabaseContext { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="db">Database Context</param>
        public LessonService(DatabaseContext db) {
            this.DatabaseContext = db;
        }

        /// <summary>
        /// Returns all lessons.
        /// </summary>
        public Lesson[] GetAllLesson() {
            return GetQueryableForLessons().ToArray();
        }

        /// <summary>
        /// Returns the lesson with the given id.
        /// </summary>
        public Lesson GetLessonWithId(int lessonId) {
            return GetQueryableForLessons()
                .Where(lesson => lesson.LessonId == lessonId).FirstOrDefault();
        }

        private IQueryable<Lesson> GetQueryableForLessons()
        {
            return DatabaseContext
                .Lessons
                .Include(lesson => lesson.Quizzes)
                .Include(lesson => lesson.VideoContents)
                .Include(lesson => lesson.DocumentContents);
        }
    }
}