using SEIIApp.Server.Domain;
using System;
using System.Collections.Generic;


namespace SEIIApp.Server.DataAccess
{
    public static class ContentData
    {
        private static DatabaseContext db;
        private static Random rnd = new Random();
        private const int NUMBER_OF_COURSES = 5;

        /// <summary>
        /// Initialize data for local-in-memory database.
        /// </summary>
        /// <param name="db">Database context</param>
        public static void GenerateData(DatabaseContext db)
        {
            ContentData.db = db;
            GenerateCourse1();
            GenerateStudent();
            GenerateItems();
            db.SaveChanges();
        }
        private static void GenerateCourse1()
        {
            Course course1 = new Course();
            course1.Title = "Neonatal Nutrition and Maternal Factors";
            course1.Description = "Effects of nutritional factors related to infant growth and development, especially related to human milk.";
            course1.Lessons = GenerateLessons(rnd.Next(2, 8));
            db.Courses.Add(course1);

            Course course = new Course();
            course.Title = "Newborn resuscitation and support of transition of infants at birth";
            course.Description = "Basic concepst acording to the European Resuscitation Council Guidelines 2021";
            course.Lessons = GenerateLessons1();
            db.Courses.Add(course);

            Course course2 = new Course();
            course2.Title = "Extremely Premature Infant Care";
            course2.Description = "Measures, treatments and medication";
            course2.Lessons = GenerateLessons(rnd.Next(2, 8));
            db.Courses.Add(course2);

            Course course3 = new Course();
            course3.Title = "Feeding Disorders";
            course3.Description = "Tipps and techniques to cure or prevent feeding disorders";
            course3.Lessons = GenerateLessons(rnd.Next(2, 8));
            db.Courses.Add(course3);

        }

        private static List<Lesson> GenerateLessons1()
        {
            List<Lesson> lessons = new List<Lesson>();
            // 1st Lesson
            Lesson lesson = new Lesson();
            lesson.Title = "Newborn resuscitation";
            lesson.Description = "Basic knowledge and techniques";
            lesson.VideoContents = GenerateVideoContent1(lesson);
            lesson.DocumentContents = GenerateDocumentsContents1(lesson);
            lesson.Quizzes = GenerateQuizzes1();
            lessons.Add(lesson);
            // 2nd Lesson
            Lesson lesson2 = new Lesson();
            lesson2.Title = "Support of transition of infants at birth";
            lesson2.Description = "Step by step introduction";

            lessons.Add(lesson2);

            return lessons;
        }
        private static List<VideoContent> GenerateVideoContent1(Lesson lesson)
        {
            List<VideoContent> videoContents = new List<VideoContent>();

            VideoContent videoContent = new VideoContent();
            videoContent.Title = "Neonatal Resuscitation - Demonstration";
            videoContent.Lessons = new List<Lesson>();
            videoContent.Lessons.Add(lesson);
            videoContent.Location = new Uri("https://www.youtube.com/embed/0WhEtCygUJM");
            videoContents.Add(videoContent);

            return videoContents;
        }
        private static void GenerateItems()
        {
            string[] sources = { "images/glasses.png", "/images/hat.png", "/images/mask.png" };
            string[] sourcesButtons = { "/images/glasses_button.png", "/images/hat_button.png", "/images/mask_button.png" };
            for (int i = 0; i < sources.Length; i++)
            {
                AvatarItem item = new AvatarItem();
                item.Source = sources[i];
                item.SourceButton = sourcesButtons[i];
                db.Add(item);
            }
        }

        private static void GenerateStudent()
        {
            Student student = new Student();
            student.EmailAddress = "test@test.test";
            student.Profile = GenerateProfile();
            student.Avatar = GenerateAvatar();
            student.CorrectQuestions = new List<CorrectQuestion>();
            db.Students.Add(student);
        }

        private static StudentProfile GenerateProfile()
        {
            StudentProfile profile = new StudentProfile();
            profile.Name = "Simon";
            profile.Description = "Beschreibung des Typen";
            profile.Experience = 0;
            return profile;
        }

        private static Avatar GenerateAvatar()
        {
            Avatar avatar = new Avatar();
            avatar.Location = "/images/avatar.png";
            return avatar;
        }





        private static List<DocumentContent> GenerateDocumentsContents1(Lesson lesson)
        {
            List<DocumentContent> DocumentContents = new List<DocumentContent>();

            DocumentContent DocumentContent = new DocumentContent();
            DocumentContent.Title = "Newborn resuscitation and support of transition of infants at birth";
            DocumentContent.Lessons = new List<Lesson>();
            DocumentContent.Lessons.Add(lesson);
            DocumentContent.Location = new Uri("https://cprguidelines.eu/assets/guidelines/RESUS-8907-NLS.pdf");
            DocumentContents.Add(DocumentContent);

            DocumentContent DocumentContent1 = new DocumentContent();
            DocumentContent1.Title = "Special Report-Neonatal Resuscitation";
            DocumentContent1.Lessons = new List<Lesson>();
            DocumentContent1.Lessons.Add(lesson);
            DocumentContent1.Location = new Uri("https://www.researchgate.net/profile/Louis-Halamek/publication/47459399_Special_Report-Neonatal_Resuscitation_2010_American_Heart_Association_Guidelines_for_Cardiopulmonary_Resuscitation_and_Emergency_Cardiovascular_Care/links/57c6357f08ae6db2cc76aec8/Special-Report-Neonatal-Resuscitation-2010-American-Heart-Association-Guidelines-for-Cardiopulmonary-Resuscitation-and-Emergency-Cardiovascular-Care.pdf");
            DocumentContents.Add(DocumentContent1);

            return DocumentContents;
        }

        private static List<Quiz> GenerateQuizzes1()
        {
            List<Quiz> quizzes = new List<Quiz>();


            Quiz quiz = new Quiz();
            quiz.Title = "Newborn first aid in the delivery room";
            quiz.Questions = GenerateQuestions1();
            quizzes.Add(quiz);

            return quizzes;
        }

        private static List<Question> GenerateQuestions1()
        {
            List<Question> questions = new List<Question>();

            Question question = new Question();
            question.QuestionText = "Which statements about first aid for newborns is correct?";
            question.CreationDateTime = DateTime.Now;
            question.Answers = GenerateAnswers1();
            questions.Add(question);

            Question question1 = new Question();
            question1.QuestionText = "The most important step when resuscitating a compromised infant is to...";
            question1.CreationDateTime = DateTime.Now;
            question1.Answers = GenerateAnswers2();
            questions.Add(question1);

            Question question2 = new Question();
            question2.QuestionText = "Chest	compressionsin infants are indicated when heart	rate remains less than _______ bpm despite ___________ seconds of effective PPV";
            question2.CreationDateTime = DateTime.Now;
            question2.Answers = GenerateAnswers3();
            questions.Add(question2);

            Question question3 = new Question();
            question3.QuestionText = "An Apgar score below 7 indicates that a newborn needs	resuscitation";
            question3.CreationDateTime = DateTime.Now;
            question3.Answers = GenerateAnswers4();
            questions.Add(question3);

            Question question4 = new Question();
            question4.QuestionText = "Select the CORRECT practice for babies who do	not	respond	to resuscitation.";
            question4.CreationDateTime = DateTime.Now;
            question4.Answers = GenerateAnswers5();
            questions.Add(question4);
            return questions;
        }

        private static List<Answer> GenerateAnswers1()
        {
            List<Answer> answers = new List<Answer>();


            Answer answer = new Answer();
            answer.AnswerText = "The majority of all newborns do not require any special medical support after birth";
            answer.Correct = false;
            answers.Add(answer);

            Answer answer1 = new Answer();
            answer1.AnswerText = "The maintenance of temperature (36.5 - 37.5 ° C) after birth is of great importance for all healthy newborns.";
            answer1.Correct = true;
            answers.Add(answer1);

            Answer answer2 = new Answer();
            answer2.AnswerText = "Only about 2% of all newborns have to be ventilated after birth";
            answer2.Correct = false;
            answers.Add(answer2);

            Answer answer3 = new Answer();
            answer3.AnswerText = "Approximately 96% of all newborns have to be intubated after birth.";
            answer3.Correct = false;
            answers.Add(answer3);

            Answer answer4 = new Answer();
            answer4.AnswerText = "Drug therapy plays a bigger role than cardiac pressure massage";
            answer4.Correct = false;
            answers.Add(answer4);

            return answers;
        }

        private static List<Answer> GenerateAnswers2()
        {
            List<Answer> answers = new List<Answer>();


            Answer answer = new Answer();
            answer.AnswerText = "Stabilize heart rate and	rhythm";
            answer.Correct = false;
            answers.Add(answer);

            Answer answer1 = new Answer();
            answer1.AnswerText = "Expand circulating blood volume";
            answer1.Correct = false;
            answers.Add(answer1);

            Answer answer2 = new Answer();
            answer2.AnswerText = "Perform tactile stimulation";
            answer2.Correct = false;
            answers.Add(answer2);

            Answer answer3 = new Answer();
            answer3.AnswerText = "Ventilate	the	lungs";
            answer3.Correct = true;
            answers.Add(answer3);



            return answers;
        }
        private static List<Answer> GenerateAnswers3()
        {
            List<Answer> answers = new List<Answer>();


            Answer answer = new Answer();
            answer.AnswerText = "100/60";
            answer.Correct = false;
            answers.Add(answer);

            Answer answer1 = new Answer();
            answer1.AnswerText = "60/15";
            answer1.Correct = false;
            answers.Add(answer1);

            Answer answer2 = new Answer();
            answer2.AnswerText = "60/30";
            answer2.Correct = true;
            answers.Add(answer2);

            Answer answer3 = new Answer();
            answer3.AnswerText = "100/30";
            answer3.Correct = false;
            answers.Add(answer3);


            return answers;
        }
        private static List<Answer> GenerateAnswers4()
        {
            List<Answer> answers = new List<Answer>();


            Answer answer = new Answer();
            answer.AnswerText = "True";
            answer.Correct = false;
            answers.Add(answer);

            Answer answer1 = new Answer();
            answer1.AnswerText = "False";
            answer1.Correct = true;
            answers.Add(answer1);




            return answers;
        }
        private static List<Answer> GenerateAnswers5()
        {
            List<Answer> answers = new List<Answer>();


            Answer answer = new Answer();
            answer.AnswerText = "Administer PPV	by mask	if a diaphragmatic hernia is suspected";
            answer.Correct = false;
            answers.Add(answer);

            Answer answer1 = new Answer();
            answer1.AnswerText = "Place	an oral	airway to stabilize an infant with Robin syndrome";
            answer1.Correct = false;
            answers.Add(answer1);

            Answer answer2 = new Answer();
            answer2.AnswerText = "Perform transillumination	if pneumothorax is suspected";
            answer2.Correct = true;
            answers.Add(answer2);

            Answer answer3 = new Answer();
            answer3.AnswerText = "Administer naloxone if PPV fails to normalize	heart rate";
            answer3.Correct = false;
            answers.Add(answer3);



            return answers;

        }
        private static List<Lesson> GenerateLessons(int noOfLessons)
        {
            List<Lesson> lessons = new List<Lesson>();
            for (int i = 1; i <= noOfLessons; i++)
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
            for (int i = 1; i <= noOfVideoContent; i++)
            {
                VideoContent videoContent = new VideoContent();
                videoContent.Title = "Neonatal Resuscitation - Demonstration";
                videoContent.Lessons = new List<Lesson>();
                videoContent.Lessons.Add(lesson);
                videoContent.Location = new Uri("https://www.youtube.com/embed/0WhEtCygUJM");
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
                DocumentContent.Title = "Newborn resuscitation and support of transition of infants at birth";
                DocumentContent.Lessons = new List<Lesson>();
                DocumentContent.Lessons.Add(lesson);
                DocumentContent.Location = new Uri("https://cprguidelines.eu/assets/guidelines/RESUS-8907-NLS.pdf");
                DocumentContents.Add(DocumentContent);
            }
            return DocumentContents;
        }

        private static List<Quiz> GenerateQuizzes(int noOfQuizzes)
        {
            List<Quiz> quizzes = new List<Quiz>();
            for (int i = 1; i <= noOfQuizzes; i++)
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
            for (int i = 1; i <= noOfQuestions; i++)
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
            for (int i = 1; i <= noOfAnswers; i++)
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
