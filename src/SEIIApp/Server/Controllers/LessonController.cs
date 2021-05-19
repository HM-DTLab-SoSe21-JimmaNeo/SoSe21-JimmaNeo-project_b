using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/Lessons")]
    public class LessonController : ControllerBase
    {

        private LessonService LessonService { get; set; }
        private IMapper Mapper { get; set; }

        public LessonController(LessonService LessonService, IMapper mapper)
        {
            this.LessonService = LessonService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the Lesson with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainDTOs.LessonDto> GetLessonWithId([FromRoute] int id)
        {
            var Lesson = LessonService.GetLessonWithId(id);
            if (Lesson == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedLesson = Mapper.Map<LessonDto>(Lesson);
            return Ok(mappedLesson);
        }

        /// <summary>
        /// Returns all Lessons.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<LessonDto[]> GetAllLesson()
        {
            var Lessons = LessonService.GetAllLesson();
            var mappedLessons = Mapper.Map<LessonDto[]>(Lessons);
            return Ok(mappedLessons);
        }







    }
}
