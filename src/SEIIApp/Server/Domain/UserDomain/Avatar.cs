using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class Avatar
    {
        [Key]
        public int AvatarId { get; set; }
        public string Location { get; set; }
        public List<AvatarItem> UsedItems { get; set; }
    }
}
