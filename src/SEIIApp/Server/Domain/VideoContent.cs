using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SEIIApp.Server.Domain
{
    public class VideoContent : ILessonContent
    {
        [Key]
        public int ContentId { get; set; }
        public string Title { get; set; }
        public List<Lesson> Lessons { get; set; }
        public Uri Location { get; set; }
    }
}
