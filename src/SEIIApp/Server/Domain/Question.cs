using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class Question
    {
        [Key]
        public int questionId { get; set; }
        public string questionText { get; set; }
        public List<Answer> answers { get; set; }
        public DateTime creationDateTime { get; set; }
    }
}
