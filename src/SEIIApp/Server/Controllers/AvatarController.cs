using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Controllers
{
    /// <summary>
    /// Controller for avatars.
    /// </summary>
    [ApiController]
    [Route("api/Avatars")]
    public class AvatarController : ControllerBase
    {

        private AvatarService avatarService { get; set; }
        private IMapper mapper { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="avatarService"></param>
        /// <param name="mapper"></param>
        public AvatarController(AvatarService avatarService, IMapper mapper)
        {
            this.avatarService = avatarService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Return the Avatar with the given UserId of a student.
        /// </summary>
        /// <param name="id">UserId of the student</param>
        /// <returns>The avatar of the specific student</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AvatarDto> GetAvatarWithId([FromRoute] int id)
        {
            var Avatar = avatarService.GetAvatarWithId(id);
            if (Avatar == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedAvatar = mapper.Map<AvatarDto>(Avatar);
            return Ok(mappedAvatar);
        }

        /// <summary>
        /// Update a avatar of specific student.
        /// </summary>
        /// <param name="id">UserId of the student</param>
        /// <param name="avatar">To update avatar</param>
        /// <returns>Updated avatar</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AvatarDto[]> UpdateAvatar([FromRoute] int id, [FromBody] AvatarDto avatar)
        {
            if(ModelState.IsValid)
            {
                var mappedAvatar = mapper.Map<Avatar>(avatar);
                var mappedAvatarDto = mapper.Map<AvatarDto>(avatarService.UpdateAvatar(id, mappedAvatar));
                return Ok(mappedAvatarDto);
            }
            return BadRequest(ModelState);
        }
    }
}