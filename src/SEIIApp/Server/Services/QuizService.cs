using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace SEIIApp.Server.Services
{
    public class QuizService {
        private DatabaseContext DatabaseContext { get; set; }

        public QuizService(DatabaseContext db) {
            this.DatabaseContext = db;
        }

        private IQueryable<Quiz> GetQueryableForQuizzes() {
            return DatabaseContext
                .Quizzes
                .Include(quiz => quiz.Questions)
                    .ThenInclude(question => question.Answers);
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
        /// <param name="id">Id of the quiz</param>
        /// <returns>Quiz with the given quizId</returns>
        public Quiz GetQuizWithId(int quizId){
            return GetQueryableForQuizzes()
                .Where(quiz => quiz.QuizId == quizId).FirstOrDefault();
        }
    }
}
