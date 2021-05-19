using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;
namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/Quizzes")]
    public class QuizController : ControllerBase
    {

        private QuizService quizService { get; set; }
        private IMapper mapper { get; set; }
        private LessonService lessonService;

        public QuizController(QuizService quizService, LessonService lessonService, IMapper mapper)
        {
            this.quizService = quizService;
            this.mapper = mapper;
            this.lessonService = lessonService;
        }

        /// <summary>
        /// Return the Quiz with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QuizDto> GetQuizWithId([FromRoute] int id)
        {
            var quiz = quizService.GetQuizWithId(id);
            if (quiz == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedQuiz = mapper.Map<QuizDto>(quiz);
            return Ok(mappedQuiz);
        }

        /// <summary>
        /// Returns all Quizs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<QuizDto[]> GetAllQuizzes()
        {
            var quizzes = quizService.GetAllQuizzes();
            var mappedQuizzes = mapper.Map<QuizDto[]>(quizzes);
            return Ok(mappedQuizzes);
        }

        [HttpGet]
        [Route("/api/lesson/{lessonId}/quizzes/")]
        public ActionResult<QuizDto[]> GetAllQuizzesOfLesson([FromRoute] int lessonId)
        {
            var lesson = lessonService.GetLessonWithId(lessonId);
            if (lesson == null) return StatusCode(StatusCodes.Status404NotFound);
            var quizzes = lesson.Quizzes;
            if (quizzes == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedQuizzes = mapper.Map<QuizDto[]>(quizzes);
            return mappedQuizzes;
        }
    }
}
