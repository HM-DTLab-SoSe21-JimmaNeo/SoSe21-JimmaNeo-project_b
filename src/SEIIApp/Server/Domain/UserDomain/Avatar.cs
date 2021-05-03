using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Avatar
    {
        [Key]
        public int avatarId { get; set; }
        public Uri location { get; set; }
    }
}
