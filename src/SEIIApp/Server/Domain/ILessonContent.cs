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
        public int contentId { get; set; }
        public string title { get; set; }
        public List<Lesson> lessons { get; set; }
    }
}
