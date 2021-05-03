using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SEIIApp.Shared.DomainDTOs
{
    public class QuestionDto
    {
        public int questionId { get; set; }
        public string questionText { get; set; }
        public List<AnswerDto> answers { get; set; }
        public DateTime creationDateTime { get; set; }

    }
}