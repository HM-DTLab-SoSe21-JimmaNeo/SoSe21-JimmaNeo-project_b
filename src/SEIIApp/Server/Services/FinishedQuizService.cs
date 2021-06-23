using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SEIIApp.Server.Services
{
    /// <summary>
    /// Service for finishedQuizzes.
    /// </summary>
    public class FinishedQuizService
    {
        private DatabaseContext DatabaseContext { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="databaseContext">Database Context</param>
        public FinishedQuizService(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }

        /// <summary>
        /// Add a finished Quiz to a student and, if the lesson or, the lesson and the course, is finished too, add them also.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="courseId"></param>
        /// <param name="lessonId"></param>
        /// <param name="quizId"></param>
        /// <returns>True</returns>
        public bool AddFinishedQuizToStudent(int userId, int courseId, int lessonId, int quizId)
        {
            var toUpdateStudent = GetQueryableForStudent(userId);
            var finishedQuiz = new FinishedQuiz(quizId, DateTime.Now);
            toUpdateStudent.FinishedQuizzes.Add(finishedQuiz);
            finishSuperordinated(toUpdateStudent, courseId, lessonId);
            DatabaseContext.Students.Update(toUpdateStudent);
            DatabaseContext.SaveChanges();
            return true;
        }

        private Student GetQueryableForStudent(int userId)
        {
            return DatabaseContext
                .Students
                .Where(student => student.UserId == userId)
                .Include(student => student.FinishedQuizzes)
                .Include(student => student.FinishedLessons)
                .Include(student => student.FinishedCourses)
                .FirstOrDefault();
        }

        private Course GetQueryableForCourse(int courseId)
        {
            return DatabaseContext
                .Courses
                .Where(course => course.CourseId == courseId)
                .Include(course => course.Lessons)
                .FirstOrDefault();
        }

        private Lesson GetQueryableForLesson(int lessonId)
        {
            return DatabaseContext
                .Lessons
                .Where(lesson => lesson.LessonId == lessonId)
                .Include(lesson => lesson.Quizzes)
                .FirstOrDefault();
        }

        private void finishSuperordinated(Student toUpdateStudent, int courseId, int lessonId)
        {
            if(isLessonFinished(lessonId, toUpdateStudent.FinishedQuizzes))
            {
                FinishedLesson finishedLesson = new FinishedLesson(lessonId, DateTime.Now);
                toUpdateStudent.FinishedLessons.Add(finishedLesson);
                if (isCourseFinished(courseId, toUpdateStudent.FinishedLessons))
                {
                    FinishedCourse finishedCourse = new FinishedCourse(courseId, DateTime.Now);
                    toUpdateStudent.FinishedCourses.Add(finishedCourse);
                }
            }
        }

        private bool isLessonFinished(int lessonId, List<FinishedQuiz> allfinishedQuizzesOfStudent)
        {
            var allQuizzesOfLesson = GetQueryableForLesson(lessonId).Quizzes;
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
            var allLessonsOfCourse = GetQueryableForCourse(courseId).Lessons;
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
