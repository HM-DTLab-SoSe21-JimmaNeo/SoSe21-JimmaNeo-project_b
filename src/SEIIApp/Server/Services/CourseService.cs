using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;


namespace SEIIApp.Server.Services {
    /// <summary>
    /// Service for Courses.
    /// </summary>
    public class CourseService {
        private DatabaseContext DatabaseContext { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db">Database Context</param>
        public CourseService(DatabaseContext db) {
            this.DatabaseContext = db;
        }

        /// <summary>
        /// Returns all courses.
        /// </summary>
        public Course[] GetAllCourses() {
            return GetQueryableForCourses().ToArray();
        }

        /// <summary>
        /// Returns the course with the given courseId.
        /// </summary>
        public Course GetCourseWithId(int courseId) {
            return GetQueryableForCourses()
                .Where(course => course.CourseId == courseId).FirstOrDefault();
        }

        private IQueryable<Course> GetQueryableForCourses()
        {
            return DatabaseContext
                .Courses
                .Include(course => course.Lessons);
        }
    }
}
