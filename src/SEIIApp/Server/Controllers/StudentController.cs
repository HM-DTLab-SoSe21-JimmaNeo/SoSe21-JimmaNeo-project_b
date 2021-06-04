using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Domain;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Controllers
{

    [ApiController]
    [Route("api/Students")]
    public class StudentController : ControllerBase
    {

        private StudentService studentService { get; set; }
        private FinishedQuizService finishedQuizService { get; set; }
        private IMapper mapper { get; set; }

        public StudentController(StudentService studentService, FinishedQuizService finishedQuizService, IMapper mapper)
        {
            this.studentService = studentService;
            this.finishedQuizService = finishedQuizService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Return the Student with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentDto> GetStudentWithId([FromRoute] int id)
        {
            var student = studentService.GetStudentWithId(id);
            if (student == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedStudent = mapper.Map<StudentDto>(student);
            return Ok(mappedStudent);
        }

        /// <summary>
        /// Returns all Students.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<StudentDto[]> GetAllStudents()
        {
            var students = studentService.GetAllStudents();
            var mappedStudents = mapper.Map<StudentDto[]>(students);
            return Ok(mappedStudents);
        }


        [HttpPut("{userId}/finishQuiz/{courseId}/{lessonId}/{quizId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public bool AddFinishedQuizToStudent([FromRoute] int userId, [FromRoute] int courseId, [FromRoute] int lessonId, [FromRoute] int quizId)
        {              
                return finishedQuizService.AddFinishedQuizToStudent(userId, courseId, lessonId, quizId);
        }
    }
}
