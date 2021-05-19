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
        public StudentProfileDto Profile { get; set; }
        public AvatarDto Avatar { get; set; }
        public List<CorrectQuestionDto> CorrectQuestions { get; set; }
    }
}
