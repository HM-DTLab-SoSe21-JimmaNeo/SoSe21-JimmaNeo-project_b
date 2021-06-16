using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;


namespace SEIIApp.Server.Controllers
{
    /// <summary>
    /// Controller for AvatarItems
    /// </summary>
    [ApiController]
    [Route("api/AvatarItems/")]
    public class AvatarItemController : ControllerBase
    {
        private AvatarItemService AvatarItemService { get; set; }
        private IMapper Mapper { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="avatarItemService">SServices for AvatarItems</param>
        /// <param name="mapper">Mapper</param>
        public AvatarItemController(AvatarItemService avatarItemService, IMapper mapper)
        {
            this.AvatarItemService = avatarItemService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return all AvatarItems.
        /// </summary>
        /// <returns>All AvatarItems</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<AvatarItemDto> GetAllAvatarItems()
        {
            var avatarItems = AvatarItemService.GetAllAvatarItems();
            var mappedAvatarItems = Mapper.Map<AvatarItemDto[]>(avatarItems);
            return Ok(mappedAvatarItems);
        }
    }
}
