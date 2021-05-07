using System;
using System.Collections.Generic;

namespace SEIIApp.Shared.DomainDTOs
{
    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}