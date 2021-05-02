using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;


namespace SEIIApp.Server.DataAccess
{
    public static class TestDataGenerator {
        private static DatabaseContext db;
        private static Random rnd = new Random();
        private const int NUMBER_OF_COURSES = 5;

        /// <summary>
        /// Initialize teast data for local-in-memory database.
        /// </summary>
        /// <param name="db">Database context</param>
        public static void GenerateData(DatabaseContext db)
        {
            TestDataGenerator.db = db;
            GenerateCourses(NUMBER_OF_COURSES);
        }

        private static void GenerateCourses(int noOfCourses)
        {
            for(int i = 1; i <= noOfCourses; i++)
            {
                Course course = new Course();
                course.courseId = i;
                course.title = "Title of course " + i;
                course.description = "Discription to course" + i +
                    ". Perhaps also testing with much longer text";
                course.lessons = GenerateLessons(rnd.Next(2, 15));
                db.Add(course);
            }
        }

        private static List<Lesson> GenerateLessons(int noOfLessons)
        {
            List<Lesson> lessons = new List<Lesson>();
            for(int i = 1; i <= noOfLessons; i++)
            {
                Lesson lesson = new Lesson();
                lesson.lessonId = i;
                lesson.title = i + ". Lesson title";
                lesson.description = "Hier könnte Ihre Werbung stehen (lessons.description).";
                lesson.contents = GenerateLessonContents(rnd.Next(1, 3), lesson);
                lesson.quizzes = GenerateQuizzes(rnd.Next(1, 5));
                lessons.Add(lesson);
                db.Add(lesson);
            }
            return lessons;
        }

        private static List<ILessonContent> GenerateLessonContents(int noOfContent, Lesson lesson)
        {
            List<ILessonContent> lessonContents = new List<ILessonContent>();
            for(int i = 1; i <= noOfContent; i++)
            {
                VideoContent videoContent= new VideoContent();
                DocumentContent documentContent = new DocumentContent();
                videoContent.contentId = i;
                documentContent.contentId = i + noOfContent;
                videoContent.title = "Videocontent numbero " + i;
                documentContent.title = "Documentcontent numbero " + i;
                videoContent.lessons = new List<Lesson>();
                videoContent.lessons.Add(lesson);
                documentContent.lessons = new List<Lesson>();
                documentContent.lessons.Add(lesson);
                videoContent.location = new Uri("https://www.youtube.com/watch?v=_lEzN8C5c7k");
                documentContent.location = new Uri("https://www.mathematik.hu-berlin.de/~baum/Skript/Analysis-BA-WS11-Summe.pdf");
                lessonContents.Add(videoContent);
                lessonContents.Add(documentContent);
                db.Add(videoContent);
                db.Add(documentContent);
            }
            return lessonContents;
        }

        private static List<Quiz> GenerateQuizzes(int noOfQuizzes)
        {
            List<Quiz> quizzes = new List<Quiz>();
            for(int i = 1; i <= noOfQuizzes; i++)
            {
                Quiz quiz = new Quiz();
                quiz.quizId = i;
                quiz.title = i + ". quiz title";
                quiz.questions = GenerateQuestions(rnd.Next(1, 10));
                quizzes.Add(quiz);
                db.Add(quiz);
            }
            return quizzes;
        }

        private static List<Question> GenerateQuestions(int noOfQuestions)
        {
            List<Question> questions = new List<Question>();
            for(int i = 1; i <= noOfQuestions; i++)
            {
                Question question = new Question();
                question.questionId = i;
                question.questionText = i + ". question";
                question.creationDateTime = DateTime.Now;
                question.answers = GenerateAnswers(rnd.Next(2, 6));
                questions.Add(question);
                db.Add(question);
            }
            return questions;
        }

        private static List<Answer> GenerateAnswers(int noOfAnswers)
        {
            List<Answer> answers = new List<Answer>();
            for(int i = 1; i <= noOfAnswers; i++)
            {
                Answer answer = new Answer();
                answer.answerText = i + ". answer of " + noOfAnswers + " answers.";
                if (i == 1) answer.correct = true;
                else answer.correct = false;
                answers.Add(answer);
                db.Add(answer);
            }
            return answers;
        }
    }
}