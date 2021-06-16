using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Controllers
{
    /// <summary>
    /// Controller for correctQuestions.
    /// </summary>
    [ApiController]
    [Route("api/CorrectQuestions")]
    public class CorrectQuestionController : ControllerBase
    {
        private CorrectQuestionService CqService { get; set; }
        private IMapper Mapper { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cqService">Service for CorrectQuestions</param>
        /// <param name="mapper">Mapper</param>
        public CorrectQuestionController(CorrectQuestionService cqService, IMapper mapper)
        {
            this.CqService = cqService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Get all correctQuestions of a student.
        /// </summary>
        /// <param name="id">UserId of the student</param>
        /// <returns>All correctQuestions of the student</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CorrectQuestionDto[]> GetCorrectQuestionsOfStudent([FromRoute] int id)
        {
            var correctQuestions = CqService.GetCorrectQuestionsOfStudent(id);
            if (correctQuestions == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedCorrectQuestions = Mapper.Map<CorrectQuestionDto[]>(correctQuestions);
            return Ok(mappedCorrectQuestions);
        }

        /// <summary>
        /// Add a correctQuestion to a student. The student gains experience, if a correctQuestion is added.
        /// </summary>
        /// <param name="id">UserId of the student</param>
        /// <param name="correctQuestion">CorrectQuestion to add</param>
        /// <returns>All correctQuestion of the student</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CorrectQuestionDto[]> AddCorrectQuestionToStudent([FromRoute] int id, [FromBody] CorrectQuestion correctQuestion)
        {
            if(ModelState.IsValid)
            {
                var mappedCorrectQuestion = Mapper.Map<CorrectQuestion>(correctQuestion);
                var mappedCorrectQuestionDto = Mapper.Map<CorrectQuestionDto[]>(CqService.AddCorrectQuestionToStudent(id, mappedCorrectQuestion));
                return Ok(mappedCorrectQuestionDto);
            }
            return BadRequest(ModelState);
        }
    }
}