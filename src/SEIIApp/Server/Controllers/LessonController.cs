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

        private LessonService lessonService { get; set; }
        private IMapper mapper { get; set; }

        public LessonController(LessonService lessonService, IMapper mapper)
        {
            this.lessonService = lessonService;
            this.mapper = mapper;
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
            var lesson = lessonService.GetLessonWithId(id);
            if (lesson == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedLesson = mapper.Map<LessonDto>(lesson);
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
            var lessons = lessonService.GetAllLesson();
            var mappedLessons = mapper.Map<LessonDto[]>(lessons);
            return Ok(mappedLessons);
        }







    }
}
