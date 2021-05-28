using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace SEIIApp.Server.Services
{
    public class StudentService {
        private DatabaseContext databaseContext { get; set; }
        IMapper mapper { get; set; }
        public StudentService(DatabaseContext db, IMapper mapper) {
            this.databaseContext = db;
            this.mapper = mapper;
        }

        private IQueryable<Student> GetQueryableForStudents() {
            return databaseContext
                .Students
                .Include(student => student.CorrectQuestions)
                .Include(student => student.Profile)
                .Include(student => student.Avatar)
                .Include(student => student.Avatar.UsedItems);
        }

        public Student[] GetAllStudents() {
            return GetQueryableForStudents().ToArray();
        }

        public Student GetStudentWithId(int userId) {
            return GetQueryableForStudents().Where(student => student.UserId == userId).FirstOrDefault();
        }

        public Student UpdateStudent(Student student)
        {
            var toUpdateStudent = GetStudentWithId(student.UserId);
            mapper.Map(student, toUpdateStudent);
            databaseContext.Students.Update(toUpdateStudent);
            databaseContext.SaveChanges();
            return toUpdateStudent;
        }
    }
}
