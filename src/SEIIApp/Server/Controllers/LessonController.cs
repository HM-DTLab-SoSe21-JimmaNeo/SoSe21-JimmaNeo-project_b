using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Controllers
{
    /// <summary>
    /// Controller for Lessons.
    /// </summary>
    [ApiController]
    [Route("api/Lessons")]
    public class LessonController : ControllerBase
    {
        private LessonService LessonService { get; set; }
        private IMapper Mapper { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="lessonService">Service for lessons</param>
        /// <param name="mapper">Mapper</param>
        public LessonController(LessonService lessonService, IMapper mapper)
        {
            this.LessonService = lessonService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the Lesson with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Http StatusCode, if ok LessonDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LessonDto> GetLessonWithId([FromRoute] int id)
        {
            var lesson = LessonService.GetLessonWithId(id);
            if (lesson == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedLesson = Mapper.Map<LessonDto>(lesson);
            return Ok(mappedLesson);
        }

        /// <summary>
        /// Returns all Lessons.
        /// </summary>
        /// <returns>>Http StatusCode, if ok LessonDto array</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<LessonDto[]> GetAllLesson()
        {
            var lessons = LessonService.GetAllLesson();
            var mappedLessons = Mapper.Map<LessonDto[]>(lessons);
            return Ok(mappedLessons);
        }
    }
}