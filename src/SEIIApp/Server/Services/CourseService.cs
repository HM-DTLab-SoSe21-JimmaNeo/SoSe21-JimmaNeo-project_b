using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;


namespace SEIIApp.Server.Services {
    public class CourseService {

        private DatabaseContext DatabaseContext { get; set; }
        public CourseService(DatabaseContext db) {
            this.DatabaseContext = db;
        }

        private IQueryable<Course> GetQueryableForCourses() {
            return DatabaseContext
                .Courses
                .Include(course => course.lessons);
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
                .Where(course => course.courseId == courseId).FirstOrDefault();
        }
    }
}
