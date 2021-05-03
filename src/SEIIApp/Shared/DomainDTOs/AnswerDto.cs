using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SEIIApp.Shared.DomainDTOs
{
    class AnswerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 1)]
        public string AnswerText { get; set; }

        public bool Correct { get; set; }

    }
}

