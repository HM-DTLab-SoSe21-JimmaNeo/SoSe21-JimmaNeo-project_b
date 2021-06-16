using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool Correct { get; set; }
    }
}
