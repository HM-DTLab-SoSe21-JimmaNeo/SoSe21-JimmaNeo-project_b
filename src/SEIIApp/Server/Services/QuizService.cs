using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SEIIApp.Server.Services
{
    /// <summary>
    /// Service for Quizzes.
    /// </summary>
    public class QuizService {
        private DatabaseContext DatabaseContext { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="db">Database Context</param>
        public QuizService(DatabaseContext db) {
            this.DatabaseContext = db;
        }

        /// <summary>
        /// Returns all quizzes.
        /// </summary>
        /// <returns>All quizzes</returns>
        public Quiz[] GetAllQuizzes(){
            return GetQueryableForQuizzes().ToArray();
        }

        /// <summary>
        /// Returns the quiz with the given quizId.
        /// </summary>
        /// <param name="quizId">Id of the quiz</param>
        /// <returns>Quiz with the given quizId</returns>
        public Quiz GetQuizWithId(int quizId){
            return GetQueryableForQuizzes()
                .Where(quiz => quiz.QuizId == quizId).FirstOrDefault();
        }

        private IQueryable<Quiz> GetQueryableForQuizzes()
        {
            return DatabaseContext
                .Quizzes
                .Include(quiz => quiz.Questions)
                    .ThenInclude(question => question.Answers);
        }
    }
}