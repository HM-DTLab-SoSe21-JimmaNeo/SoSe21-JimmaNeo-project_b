using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainDTOs
{
    public class StudentDto
    {
        public int userId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StudentProfileDto profile { get; set; }
        public AvatarDto avatar { get; set; }
        public List<CorrectQuestionDto> correctQuestions { get; set; }
    }
}
