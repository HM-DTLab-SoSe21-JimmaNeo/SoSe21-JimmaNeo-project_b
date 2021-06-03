using SEIIApp.Server.DataAccess;
using SEIIApp.Server.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SEIIApp.Server.Services
{
    /// <summary>
    /// Service for avatars.
    /// </summary>
    public class AvatarService
    {
        private DatabaseContext databaseContext { get; set; }
   
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="db"></param>
        public AvatarService(DatabaseContext db)
        {
            this.databaseContext = db;
        }

        private IQueryable<Avatar> GetQueryableForAvatars()
        {
            return databaseContext
                .Avatars
                .Include(avatar => avatar.UsedItems);
        }

        private IQueryable<Student> GetQueryableForStudents()
        {
            return databaseContext
                .Students
                .Include(student => student.Avatar)
                .ThenInclude(avatar => avatar.UsedItems);
        }

        /// <summary>
        /// Get the avatar of a specific student.
        /// </summary>
        /// <param name="userId">UserId of the specific student</param>
        /// <returns>The avatar of the specific student</returns>
        public Avatar GetAvatarWithId(int userId)
        {
            return (from student in GetQueryableForStudents()
                            where student.UserId == userId
                            select student.Avatar).FirstOrDefault();
        }

        /// <summary>
        /// Update the avatar of a specific student.
        /// </summary>
        /// <param name="userId">UserId of the specific student</param>
        /// <param name="avatar">The new avatar</param>
        /// <returns>The updated avatar</returns>
        public Avatar UpdateAvatar(int userId, Avatar avatar)
        {
            var toUpdateStudent = GetQueryableForStudents().Where(student => student.UserId == userId).FirstOrDefault();
            toUpdateStudent.Avatar = avatar;
            databaseContext.Avatars.Update(avatar);
            databaseContext.SaveChanges();
            return toUpdateStudent.Avatar;
        }       
    }
}
