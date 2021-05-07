using System;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Avatar
    {
        [Key]
        public int AvatarId { get; set; }
        public Uri Location { get; set; }
    }
}
