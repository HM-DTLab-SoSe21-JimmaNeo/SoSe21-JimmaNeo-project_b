using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class Lesson
    {
        [Key]
        public int lessonId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<Quiz> quizzes { get; set; }
        //public List<ILessonContent> contents { get; set; }
        public List<VideoContent> videoContents { get; set; }

        public List<DocumentContent> documentContents { get; set; }
    }
}
