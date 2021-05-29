using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/Avatars")]
    public class AvatarController : ControllerBase
    {

        private AvatarService avatarService { get; set; }
        private IMapper mapper { get; set; }

        public AvatarController(AvatarService AvatarService, IMapper mapper)
        {
            this.avatarService = AvatarService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Return the Avatar with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// Returns all Avatars.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<AvatarDto[]> GetAllAvatars()
        {
            var Avatars = avatarService.GetAllAvatars();
            var mappedAvatars = mapper.Map<AvatarDto[]>(Avatars);
            return Ok(mappedAvatars);
        }

    }
}
