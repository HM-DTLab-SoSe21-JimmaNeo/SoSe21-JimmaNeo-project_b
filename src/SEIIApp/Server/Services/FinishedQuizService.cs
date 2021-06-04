using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SEIIApp.Server.Services
{
    /// <summary>
    /// Service for finishedQuizzes
    /// </summary>
    public class FinishedQuizService
    {
        private DatabaseContext databaseContext { get; set; }

        public FinishedQuizService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        private IQueryable<Student> GetQueryableForStudents()
        {
            return databaseContext
                .Students
                .Include(student => student.FinishedQuizzes)
                .Include(student => student.FinishedLessons)
                .Include(student => student.FinishedCourses);
        }

        private IQueryable<Lesson> GetQueryableForLesson()
        {
            return databaseContext
                .Lessons
                .Include(lesson => lesson.Quizzes);
        }

        private IQueryable<Course> GetQueryableForCourse()
        {
            return databaseContext
                .Courses
                .Include(course => course.Lessons);
        }

        /// <summary>
        /// Add a finished Quiz to a student and if the lesson or the lesson and the course is finished too add them also.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="finishedQuiz"></param>
        /// <returns></returns>
        public FinishedQuiz[] AddFinishedQuizToStudent(int userId, FinishedQuiz finishedQuiz)
        {
            var toUpdateStudent = GetQueryableForStudents()
                .Where(student => student.UserId == userId)
                .FirstOrDefault();
            finishedQuiz.FinishedDateTime = DateTime.Now;
            toUpdateStudent.FinishedQuizzes.Add(finishedQuiz);
            finishSuperordinated(toUpdateStudent, finishedQuiz);
            databaseContext.Students.Update(toUpdateStudent);
            databaseContext.SaveChanges();
            return toUpdateStudent.FinishedQuizzes.ToArray();
        }

        private void finishSuperordinated(Student toUpdateStudent, FinishedQuiz finishedQuiz)
        {       
            if(isLessonFinished(finishedQuiz.LessonId, toUpdateStudent.FinishedQuizzes))
            {
                FinishedLesson finishedLesson = new FinishedLesson();
                finishedLesson.LessonId = finishedQuiz.LessonId;
                finishedLesson.FinishedDateTime = finishedQuiz.FinishedDateTime;
                toUpdateStudent.FinishedLessons.Add(finishedLesson);
                if (isCourseFinished(finishedQuiz.CourseId, toUpdateStudent.FinishedLessons))
                {
                    FinishedCourse finishedCourse = new FinishedCourse();
                    finishedCourse.CourseId = finishedQuiz.CourseId;
                    finishedCourse.FinishedDateTime = finishedQuiz.FinishedDateTime;
                    toUpdateStudent.FinishedCourses.Add(finishedCourse);
                }
            }
        }

        private bool isLessonFinished(int lessonId, List<FinishedQuiz> allfinishedQuizzesOfStudent)
        {
            List<Quiz> allQuizzesOfLesson = GetQueryableForLesson()
                .Where(lesson => lesson.LessonId == lessonId)
                .FirstOrDefault()
                .Quizzes;
            for(int i = 0; i < allQuizzesOfLesson.Count; i++)
            {
                bool quizFinishedByStudent = false;
                for(int j = 0; j < allfinishedQuizzesOfStudent.Count; j++)
                {
                    if(allQuizzesOfLesson[i].QuizId == allfinishedQuizzesOfStudent[j].QuizId)
                    {
                        quizFinishedByStudent = true;
                        break;
                    }
                }
                if (!quizFinishedByStudent)
                    return false;
            }
            return true;
        }

        private bool isCourseFinished(int courseId, List<FinishedLesson> allFinishedLessonsOfStudent)
        {
            List<Lesson> allLessonsOfCourse = GetQueryableForCourse()
                .Where(course => course.CourseId == courseId)
                .FirstOrDefault()
                .Lessons;
            for (int i = 0; i < allLessonsOfCourse.Count; i++)
            {
                bool quizFinishedByStudent = false;
                for (int j = 0; j < allFinishedLessonsOfStudent.Count; j++)
                {
                    if (allLessonsOfCourse[i].LessonId == allFinishedLessonsOfStudent[j].LessonId)
                    {
                        quizFinishedByStudent = true;
                        break;
                    }
                }
                if (!quizFinishedByStudent)
                    return false;
            }
            return true;
        }
    }
}
