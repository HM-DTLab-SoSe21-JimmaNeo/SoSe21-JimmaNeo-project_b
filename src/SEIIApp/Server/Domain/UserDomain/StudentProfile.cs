using System.ComponentModel.DataAnnotations;

namespace SEIIApp.Server.Domain
{
    public class StudentProfile
    {
        [Key]
        public int StudentProfileId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Experience { get; set; }
    }
}
