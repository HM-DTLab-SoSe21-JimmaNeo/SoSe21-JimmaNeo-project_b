using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class AvatarItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Source { get; set; }
        public string SourceButton { get; set; }
    }
}
