using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class CorrectQuestion
    {
        [Key]
        public int Id { get; set; }

        //Reference to the question id
        public int QuestionsId { get; set; }

        public DateTime SolveDateTime { get; set; }
    }
}
