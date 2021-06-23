using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace SEIIApp.Server.Services
{
    /// <summary>
    /// Service for student.
    /// </summary>
    public class StudentService {
        private DatabaseContext DatabaseContext { get; set; }
        private IMapper Mapper { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        /// <param name="cqs"></param>
        public StudentService(DatabaseContext db, IMapper mapper, CorrectQuestionService cqs) {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>All students</returns>
        public Student[] GetAllStudents() {
            return GetQueryableForStudents().ToArray();
        }

        /// <summary>
        /// Gets the specified student.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Specified Student</returns>
        public Student GetStudentWithId(int userId) {
            return GetQueryableForStudents().Where(student => student.UserId == userId).FirstOrDefault();
        }

        /// <summary>
        /// Updates given student.
        /// </summary>
        /// <param name="student">To update student</param>
        /// <returns>Updated student</returns>
        public Student UpdateStudent(Student student)
        {
            var toUpdateStudent = GetStudentWithId(student.UserId);
            if (toUpdateStudent != student) {
                Mapper.Map(student, toUpdateStudent);
                DatabaseContext.Students.Update(toUpdateStudent);
                DatabaseContext.SaveChanges();
            }
            return toUpdateStudent;
        }

        private IQueryable<Student> GetQueryableForStudents()
        {
            return DatabaseContext
                .Students
                .Include(student => student.CorrectQuestions)
                .Include(student => student.Profile)
                .Include(student => student.Avatar)
                .Include(student => student.Avatar.UsedItems)
                .Include(student => student.FinishedCourses)
                .Include(student => student.FinishedLessons)
                .Include(student => student.FinishedQuizzes);
        }
    }
}
