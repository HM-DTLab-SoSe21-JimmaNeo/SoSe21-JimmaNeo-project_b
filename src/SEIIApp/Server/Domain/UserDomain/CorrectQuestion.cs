using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class CorrectQuestion
    {
        [Key]
        public int questionsId { get; set; }
        public DateTime solveDateTime { get; set; }
    }
}
