using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SEIIApp.Server.Services
{
    /// <summary>
    /// Service for correctQuestions.
    /// </summary>
    public class CorrectQuestionService
    {
        private DatabaseContext DatabaseContext { get; set; }
        private const int EXPERIENCE_GAIN = 10;

        /// <summary>
        /// Contstructor.
        /// </summary>
        /// <param name="databaseContext"></param>
        public CorrectQuestionService(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
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
            toUpdateStudent.Profile.Experience += EXPERIENCE_GAIN;
            correctQuestion.SolveDateTime = DateTime.Now;
            toUpdateStudent.CorrectQuestions.Add(correctQuestion);
            DatabaseContext.Students.Update(toUpdateStudent);
            DatabaseContext.SaveChanges();
            return toUpdateStudent.CorrectQuestions.ToArray();
        }

        private IQueryable<Student> GetQueryableForStudents()
        {
            return DatabaseContext
                .Students
                .Include(student => student.CorrectQuestions)
                .Include(student => student.Profile);
        }
    }
}
