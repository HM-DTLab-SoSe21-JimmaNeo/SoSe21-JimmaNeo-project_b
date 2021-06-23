using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainDTOs
{
    public class StudentDto
    {
        public int UserId { get; set; } 
        public string EmailAddress { get; set; }
        public StudentProfileDto Profile { get; set; }
        public AvatarDto Avatar { get; set; }
        public List<FinishedCourseDto> FinishedCourses { get; set; }
        public List<FinishedLessonDto> FinishedLessons { get; set; }
        public List<FinishedQuizDto> FinishedQuizzes { get; set; }
        public List<CorrectQuestionDto> CorrectQuestions { get; set; }
    }
}
