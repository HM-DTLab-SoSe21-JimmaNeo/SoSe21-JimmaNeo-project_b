using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Course
    {
        [Key]
        public int courseId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<Lesson> lessons { get; set; }
    }
}
