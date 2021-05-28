using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace SEIIApp.Server.Services
{
    public class AvatarService
    {
        private DatabaseContext DatabaseContext { get; set; }
        IMapper Mapper { get; set; }
        public AvatarService(DatabaseContext db, IMapper mapper)
        {
            this.DatabaseContext = db;
            this.Mapper = mapper;
        }

        private IQueryable<Avatar> GetQueryableForAvatars()
        {
            return DatabaseContext
                .Avatars
                .Include(avatar => avatar.UsedItems);
        }

        public Avatar[] GetAllAvatars()
        {
            return GetQueryableForAvatars().ToArray();
        }

        public Avatar GetAvatarWithId(int avatarId)
        {
            return GetQueryableForAvatars().Where(avatar => avatar.AvatarId == avatarId).FirstOrDefault();
        }

       
    }
}
