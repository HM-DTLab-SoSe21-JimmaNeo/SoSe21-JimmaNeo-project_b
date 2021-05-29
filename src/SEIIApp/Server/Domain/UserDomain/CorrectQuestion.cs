using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    /// <summary>
    /// Data object which represents correctly answered questions.
    /// </summary>
    public class CorrectQuestion
    {
        /// <summary>
        /// Id of the record.
        /// </summary>
        [Key]
        public int CorrectQuestionId { get; set; }
        /// <summary>
        /// Reference to the correctly answered question.
        /// </summary>
        public int QuestionsId { get; set; }
        /// <summary>
        /// Date time of answering the question correctly.
        /// </summary>
        public DateTime SolveDateTime { get; set; }
    }
}
