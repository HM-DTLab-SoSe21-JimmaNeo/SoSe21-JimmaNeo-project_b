using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using System.Linq;

namespace SEIIApp.Server.Services
{
    /// <summary>
    /// Service for AvatarItems.
    /// </summary>
    public class AvatarItemService
     {
        private DatabaseContext DatabaseContext { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db">Database Context</param>
        public AvatarItemService(DatabaseContext db)
        {
            this.DatabaseContext = db;
        }

        /// <summary>
        /// Returns all items.
        /// </summary>
        public AvatarItem[] GetAllAvatarItems()
        {
            return GetQueryableForAvatarItems().ToArray();
        }

        private IQueryable<AvatarItem> GetQueryableForAvatarItems()
        {
            return DatabaseContext.AvatarItems;
        }
    }
}
