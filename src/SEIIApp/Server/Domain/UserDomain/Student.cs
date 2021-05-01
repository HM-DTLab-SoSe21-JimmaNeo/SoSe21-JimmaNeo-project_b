using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public class Student : IUser
    {
        public int userId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public EmailAddressAttribute emailAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StudentProfile profile { get; set; }
        public Avatar avatar { get; set; }
        public List<CorrectQuestion> correctQuestions { get; set; }
    }
}
