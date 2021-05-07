using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class CorrectQuestion
    {
        [Key]
        public int QuestionsId { get; set; }
        public DateTime SolveDateTime { get; set; }
    }
}
