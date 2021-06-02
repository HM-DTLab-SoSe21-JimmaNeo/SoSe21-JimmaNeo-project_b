using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared.DomainDTOs
{
    public class AvatarDto {     
        public string Location { set; get; }
        public List<AvatarItemDto> UsedItems { get; set; }
    }
}
