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
                course.Title = "Title of course " + i;
                course.Description = "Discription to course" + i +
                    ". Perhaps also testing with much longer text";
                course.Lessons = GenerateLessons(rnd.Next(2, 15));
                db.Courses.Add(course);
            }
            db.SaveChanges();
        }

        private static List<Lesson> GenerateLessons(int noOfLessons)
        {
            List<Lesson> lessons = new List<Lesson>();
            for(int i = 1; i <= noOfLessons; i++)
            {
                Lesson lesson = new Lesson();
                lesson.Title = i + ". Lesson title";
                lesson.Description = "Hier könnte Ihre Werbung stehen (lessons.description).";
                //lesson.videoContents = GenerateVideoContents(rnd.Next(1, 3), lesson);
                lesson.VideoContents = GenerateVideoContents(rnd.Next(1, 2), lesson);
                lesson.DocumentContents = GenerateDocumentsContents(rnd.Next(1, 2), lesson);                
                lesson.Quizzes = GenerateQuizzes(rnd.Next(1, 5));
                lessons.Add(lesson);
            }
            return lessons;
        }

        
        private static List<VideoContent> GenerateVideoContents(int noOfVideoContent, Lesson lesson)
        {
            List<VideoContent> videoContents = new List<VideoContent>();
            for(int i = 1; i <= noOfVideoContent; i++)
            {
                VideoContent videoContent = new VideoContent();
                videoContent.Title = "Videocontent numbero " + i;
                videoContent.Lessons = new List<Lesson>();
                videoContent.Lessons.Add(lesson);
                videoContent.Location = new Uri("https://www.youtube.com/watch?v=_lEzN8C5c7k");
                videoContents.Add(videoContent);
            }
            return videoContents;
        }

        private static List<DocumentContent> GenerateDocumentsContents(int noOfDocumentContent, Lesson lesson)
        {
            List<DocumentContent> DocumentContents = new List<DocumentContent>();
            for (int i = 1; i <= noOfDocumentContent; i++)
            {
                DocumentContent DocumentContent = new DocumentContent();
                DocumentContent.Title = "Documentcontent numbero " + i;
                DocumentContent.Lessons = new List<Lesson>();
                DocumentContent.Lessons.Add(lesson);
                DocumentContent.Location = new Uri("https://www.youtube.com/watch?v=_lEzN8C5c7k");
                DocumentContents.Add(DocumentContent);
            }
            return DocumentContents;
        }

        private static List<Quiz> GenerateQuizzes(int noOfQuizzes)
        {
            List<Quiz> quizzes = new List<Quiz>();
            for(int i = 1; i <= noOfQuizzes; i++)
            {
                Quiz quiz = new Quiz();
                quiz.Title = i + ". quiz title";
                quiz.Questions = GenerateQuestions(rnd.Next(1, 10));
                quizzes.Add(quiz);
            }
            return quizzes;
        }

        private static List<Question> GenerateQuestions(int noOfQuestions)
        {
            List<Question> questions = new List<Question>();
            for(int i = 1; i <= noOfQuestions; i++)
            {
                Question question = new Question();
                question.QuestionText = i + ". question";
                question.CreationDateTime = DateTime.Now;
                question.Answers = GenerateAnswers(rnd.Next(2, 6));
                questions.Add(question);
            }
            return questions;
        }

        private static List<Answer> GenerateAnswers(int noOfAnswers)
        {
            List<Answer> answers = new List<Answer>();
            for(int i = 1; i <= noOfAnswers; i++)
            {
                Answer answer = new Answer();
                answer.AnswerText = i + ". answer of " + noOfAnswers + " answers.";
                if (i == 1) answer.Correct = true;
                else answer.Correct = false;
                answers.Add(answer);
            }
            return answers;
        }
    }
}