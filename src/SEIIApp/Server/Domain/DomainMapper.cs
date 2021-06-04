using AutoMapper;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Domain
{
    public class DomainMapper : Profile
    {

        public DomainMapper()
        {

            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();

            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();

            CreateMap<DocumentContent, DocumentContentDto>();
            CreateMap<DocumentContentDto, DocumentContent>();

            CreateMap<Lesson, LessonDto>();
            CreateMap<LessonDto, Lesson>();

            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionDto, Question>();

            CreateMap<Quiz, QuizDto>();
            CreateMap<QuizDto, Quiz>();

            CreateMap<VideoContent, VideoContentDto>();
            CreateMap<VideoContentDto, VideoContent>();

            CreateMap<Avatar, AvatarDto>();
            CreateMap<AvatarDto, Avatar>();

            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            CreateMap<StudentProfile, StudentProfileDto>();
            CreateMap<StudentProfileDto, StudentProfile>();

            CreateMap<CorrectQuestion, CorrectQuestionDto>();
            CreateMap<CorrectQuestionDto, CorrectQuestion>();

            CreateMap<AvatarItem, AvatarItemDto>();
            CreateMap<AvatarItemDto, AvatarItem>();

            CreateMap<EquippedItem, EquippedItemDto>();
            CreateMap<EquippedItemDto, EquippedItem>();

            CreateMap<FinishedCourse, FinishedCourseDto>();
            CreateMap<FinishedCourseDto, FinishedCourse>();

            CreateMap<FinishedLesson, FinishedLessonDto>();
            CreateMap<FinishedLessonDto, FinishedLesson>();

            CreateMap<FinishedQuiz, FinishedQuizDto>();
            CreateMap<FinishedQuizDto, FinishedQuiz>();

            CreateMap<Student, Student>();
            CreateMap<Avatar, Avatar>();
            CreateMap<AvatarItem, AvatarItem>();
            CreateMap<StudentProfile, StudentProfile>();
            CreateMap<CorrectQuestion, CorrectQuestion>();
            CreateMap<EquippedItem, EquippedItem>();
            CreateMap<FinishedCourse, FinishedCourse>();
            CreateMap<FinishedLesson, FinishedLesson>();
            CreateMap<FinishedQuiz, FinishedQuiz>();
        }

    }
}