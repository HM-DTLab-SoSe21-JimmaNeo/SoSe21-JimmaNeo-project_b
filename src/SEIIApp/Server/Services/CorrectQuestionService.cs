using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace SEIIApp.Server.Services
{
    /// <summary>
    /// Service for correctQuestions.
    /// </summary>
    public class CorrectQuestionService
    {
        private DatabaseContext databaseContext { get; set; }
        IMapper mapper { get; set; }

        /// <summary>
        /// Contstructor.
        /// </summary>
        /// <param name="databaseContext"></param>
        /// <param name="mapper"></param>
        public CorrectQuestionService(DatabaseContext databaseContext, IMapper mapper)
        {
            this.databaseContext = databaseContext;
            this.mapper = mapper;
        }

        private IQueryable<Student> GetQueryableForStudents()
        {
            return databaseContext
                .Students
                .Include(student => student.CorrectQuestions);
        }

        /// <summary>
        /// Get all correctQuestion of a student.
        /// </summary>
        /// <param name="userId">UserId of the student</param>
        /// <returns>All correctQuestion of the student</returns>
        public CorrectQuestion[] GetCorrectQuestionsOfStudent(int userId)
        {
            List<CorrectQuestion> allCorrectQuestionsList = (List<CorrectQuestion>)(from student in GetQueryableForStudents()
                                                                                    where student.UserId == userId
                                                                                    select student.CorrectQuestions) ;
            return allCorrectQuestionsList.ToArray();
        }
        
        /// <summary>
        /// Add a correctQuestion to a student.
        /// </summary>
        /// <param name="userId">UserId of the student</param>
        /// <param name="correctQuestion">The correctQuestion to add</param>
        /// <returns>All correctQuestion of the student</returns>
        public CorrectQuestion[] AddCorrectQuestionToStudent(int userId, CorrectQuestion correctQuestion)
        {
            var toUpdateStudent = GetQueryableForStudents().Where(student => student.UserId == userId).FirstOrDefault();
            toUpdateStudent.Profile.Experience += 10;
            correctQuestion.SolveDateTime = DateTime.Now;
            toUpdateStudent.CorrectQuestions.Add(correctQuestion);
            databaseContext.Students.Update(toUpdateStudent);
            databaseContext.SaveChanges();
            return toUpdateStudent.CorrectQuestions.ToArray();
        }
    }
}
