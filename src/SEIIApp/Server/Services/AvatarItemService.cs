using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services
{
    public class AvatarItemService
     {
        private DatabaseContext DatabaseContext { get; set; }
        public AvatarItemService(DatabaseContext db)
        {
            this.DatabaseContext = db;
        }

        private IQueryable<AvatarItem> GetQueryableForAvatarItems()
        {
            return DatabaseContext.AvatarItems;
        }

        /// <summary>
        /// Returns all items.
        /// </summary>
        public AvatarItem[] GetAllAvatarItems()
        {
            return GetQueryableForAvatarItems().ToArray();
        }
    }
}
