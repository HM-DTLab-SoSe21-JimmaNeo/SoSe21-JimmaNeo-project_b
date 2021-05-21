using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/Courses")]
    public class CourseController : ControllerBase
    {

        private CourseService courseService { get; set; }
        private IMapper mapper { get; set; }

        public CourseController(CourseService CourseService, IMapper mapper)
        {
            this.courseService = CourseService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Return the Course with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Shared.DomainDTOs.CourseDto> GetCourseWithId([FromRoute] int id)
        {
            var course = courseService.GetCourseWithId(id);
            if (course == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedCourse = mapper.Map<CourseDto>(course);
            return Ok(mappedCourse);
        }

        /// <summary>
        /// Returns all Courses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CourseDto[]> GetAllCourses()
        {
            var courses = courseService.GetAllCourses();
            var mappedCourses = mapper.Map<CourseDto[]>(courses);
            return Ok(mappedCourses);
        }
    }
}
