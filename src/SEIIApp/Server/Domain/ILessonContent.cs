using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public interface ILessonContent
    {
        [Key]
        public int ContentId { get; set; }
        public string Title { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
