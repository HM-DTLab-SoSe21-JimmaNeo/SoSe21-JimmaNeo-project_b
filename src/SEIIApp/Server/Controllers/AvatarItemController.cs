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
    [Route("api/AvatarItems/")]
    public class AvatarItemController : ControllerBase
    {
        private AvatarItemService avatarItemService { get; set; }
        private IMapper mapper { get; set; }

        public AvatarItemController(AvatarItemService avatarItemService, IMapper mapper)
        {
            this.avatarItemService = avatarItemService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Return all AvatarItems.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<AvatarItemDto> GetAllAvatarItems()
        {
            var avatarItems = avatarItemService.GetAllAvatarItems();
            var mappedAvatarItems = mapper.Map<AvatarItemDto[]>(avatarItems);
            return Ok(mappedAvatarItems);
        }
    }
}
