using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    /// <summary>
    /// Data object which represents correctly answered questions.
    /// </summary>
    public class CorrectQuestion
    {
        [Key]
        public int CorrectQuestionId { get; set; }
        public int QuestionsId { get; set; }
        public DateTime SolveDateTime { get; set; }
    }
}
