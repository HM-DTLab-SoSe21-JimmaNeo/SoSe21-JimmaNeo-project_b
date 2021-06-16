using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Controllers
{
    /// <summary>
    /// Controller for Quizzes
    /// </summary>
    [ApiController]
    [Route("api/Quizzes")]
    public class QuizController : ControllerBase
    {

        private QuizService QuizService { get; set; }
        private LessonService LessonService { get; set; }
        private IMapper Mapper { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="quizService">Service for Quizzes</param>
        /// <param name="lessonService">Service for Lessons</param>
        /// <param name="mapper">Mapper</param>
        public QuizController(QuizService quizService, LessonService lessonService, IMapper mapper)
        {
            this.QuizService = quizService;
            this.Mapper = mapper;
            this.LessonService = lessonService;
        }

        /// <summary>
        /// Return the Quiz with the given id.
        /// </summary>
        /// <param name="id">Quiz id</param>
        /// <returns>Http StatusCodes, if ok QuizDto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QuizDto> GetQuizWithId([FromRoute] int id)
        {
            var quiz = QuizService.GetQuizWithId(id);
            if (quiz == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedQuiz = Mapper.Map<QuizDto>(quiz);
            return Ok(mappedQuiz);
        }

        /// <summary>
        /// Returns all Quizs.
        /// </summary>
        /// <returns>Http StatusCodes, if ok QuizDto array</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<QuizDto[]> GetAllQuizzes()
        {
            var quizzes = QuizService.GetAllQuizzes();
            var mappedQuizzes = Mapper.Map<QuizDto[]>(quizzes);
            return Ok(mappedQuizzes);
        }

        /// <summary>
        /// Get all Quizzes of a specific lesson.
        /// </summary>
        /// <param name="lessonId"></param>
        /// <returns>Http StatusCodes, if ok QuizDto array</returns>
        [HttpGet]
        [Route("/api/lesson/{lessonId}/quizzes/")]
        public ActionResult<QuizDto[]> GetAllQuizzesOfLesson([FromRoute] int lessonId)
        {
            var lesson = LessonService.GetLessonWithId(lessonId);
            if (lesson == null) return StatusCode(StatusCodes.Status404NotFound);
            var quizzes = lesson.Quizzes;
            if (quizzes == null) return StatusCode(StatusCodes.Status404NotFound);
            var mappedQuizzes = Mapper.Map<QuizDto[]>(quizzes);
            return mappedQuizzes;
        }
    }
}