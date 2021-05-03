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
    [Route("api/Quizzes")]
    public class QuizController : ControllerBase
    {

        private QuizService QuizService { get; set; }
        private IMapper Mapper { get; set; }

        public QuizController(QuizService QuizService, IMapper mapper)
        {
            this.QuizService = QuizService;
            this.Mapper = mapper;
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
        public ActionResult<Shared.DomainDTOs.QuizDto> GetQuizWithId([FromRoute] int id)
        {
            var Quiz = QuizService.GetQuizWithId(id);
            if (Quiz == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedQuiz = Mapper.Map<QuizDto>(Quiz);
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
            var Quizs = QuizService.GetAllQuizzes();
            var mappedQuizs = Mapper.Map<QuizDto[]>(Quizs);
            return Ok(mappedQuizs);
        }







    }
}
