using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class EquippedItem
    {
        [Key]
        public int EquippedItemId { get; set; }
        public int AvatarItemId { get; set; }
    }
}
