using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace SEIIApp.Server.Services
{
    public class StudentService {
        private DatabaseContext DatabaseContext { get; set; }
        IMapper Mapper { get; set; }
        public StudentService(DatabaseContext db, IMapper mapper) {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<Student> GetQueryableForStudents() {
            return DatabaseContext
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
            Mapper.Map(student, toUpdateStudent);
            DatabaseContext.Students.Update(toUpdateStudent);
            DatabaseContext.SaveChanges();
            return toUpdateStudent;
        }
    }
}
