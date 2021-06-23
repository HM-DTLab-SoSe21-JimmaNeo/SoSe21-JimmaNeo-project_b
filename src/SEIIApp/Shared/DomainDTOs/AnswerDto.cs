using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Shared.DomainDTOs
{
    public class AnswerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string AnswerText { get; set; }
        public bool Correct { get; set; }
    }
}

