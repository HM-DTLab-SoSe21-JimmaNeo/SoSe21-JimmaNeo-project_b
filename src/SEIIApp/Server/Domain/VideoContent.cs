using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SEIIApp.Server.Domain
{
    public class VideoContent : ILessonContent
    {
        [Key]
        public int contentId { get; set; }
        public string title { get; set; }
        public List<Lesson> lessons { get; set; }

        public Uri location;
    }
}
