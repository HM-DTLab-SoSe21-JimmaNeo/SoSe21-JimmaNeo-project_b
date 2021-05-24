using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class AvatarItem
    {
        [Key]
        public int ItemId { get; set; }
        public string Source { get; set; }
        //position of items are style elements and should be defined in style file
    }
}
