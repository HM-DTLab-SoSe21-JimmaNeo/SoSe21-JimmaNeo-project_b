using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Student : IUser
    {
        [Key]
        public int userId { get; set; }
        public EmailAddressAttribute emailAddress { get; set; }
        public StudentProfile profile { get; set; }
        public Avatar avatar { get; set; }
        public List<CorrectQuestion> correctQuestions { get; set; }
    }
}
