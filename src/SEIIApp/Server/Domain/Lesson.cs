using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Quiz> Quizzes { get; set; }
        public List<ILessonContent> Contents { get; set; }
        public List<VideoContent> VideoContents { get; set; }

        public List<DocumentContent> DocumentContents { get; set; }
    }
}
