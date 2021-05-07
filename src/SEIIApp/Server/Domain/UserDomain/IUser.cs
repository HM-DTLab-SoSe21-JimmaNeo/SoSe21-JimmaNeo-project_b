
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public interface IUser
    {
        [Key]
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
    }
}
