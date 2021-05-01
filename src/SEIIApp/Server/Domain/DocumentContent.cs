using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class DocumentContent : ILessonContent
    {
        public int contentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Lesson> lessons { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Uri location { get; set;}
    }
}
