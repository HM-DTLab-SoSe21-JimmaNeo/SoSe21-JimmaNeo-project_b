using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain
{
    public interface IUser
    {
        [Key]
        public int userId { get; set; }
        public EmailAddressAttribute emailAddress { get; set; }
    }
}
