using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SEIIApp.Server.Services
{
    public class StudentService {
        private DatabaseContext DatabaseContext { get; set; }

        public StudentService(DatabaseContext db) {
            this.DatabaseContext = db;
        }

        private IQueryable<Student> GetQueryableForStudents() {
            return DatabaseContext
                .Students
                .Include(student => student.correctQuestions)
                .Include(student => student.profile)
                .Include(student => student.avatar);
        }

        public Student[] GetAllStudents() {
            return GetQueryableForStudents().ToArray();
        }

        public Student GetStudentWithId(int userId) {
            return GetQueryableForStudents().Where(student => student.userId == userId).FirstOrDefault();
        }
    }
}
