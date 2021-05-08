using AutoMapper;
using SEIIApp.Shared.DomainDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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





        }

    }
}