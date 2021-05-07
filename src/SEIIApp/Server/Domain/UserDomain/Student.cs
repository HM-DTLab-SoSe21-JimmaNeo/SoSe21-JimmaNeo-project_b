using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Student : IUser
    {
        [Key]
        //ToDo: Should be a random ID
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public StudentProfile Profile { get; set; }
        public Avatar Avatar { get; set; }
        public List<CorrectQuestion> CorrectQuestions { get; set; }
    }
}
