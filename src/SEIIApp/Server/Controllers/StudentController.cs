using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEIIApp.Server.Services;
using SEIIApp.Shared.DomainDTOs;

namespace SEIIApp.Server.Controllers
{
    /// <summary>
    /// Controller for Students.
    /// </summary>
    [ApiController]
    [Route("api/Students")]
    public class StudentController : ControllerBase
    {
        private StudentService StudentService { get; set; }
        private FinishedQuizService FinishedQuizService { get; set; }
        private IMapper Mapper { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="studentService">Service for Students</param>
        /// <param name="finishedQuizService">Service for finished quizzes</param>
        /// <param name="mapper">Mapper</param>
        public StudentController(StudentService studentService, FinishedQuizService finishedQuizService, IMapper mapper)
        {
            this.StudentService = studentService;
            this.FinishedQuizService = finishedQuizService;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Return the Student with the given id.
        /// </summary>
        /// <param name="id">Id of the student</param>
        /// <returns>Http StatusCode, if ok the student as dto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentDto> GetStudentWithId([FromRoute] int id)
        {
            var student = StudentService.GetStudentWithId(id);
            if (student == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedStudent = Mapper.Map<StudentDto>(student);
            return Ok(mappedStudent);
        }

        /// <summary>
        /// Returns all Students.
        /// </summary>
        /// <returns>Http StatusCode, if ok the students as dto array</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<StudentDto[]> GetAllStudents()
        {
            var students = StudentService.GetAllStudents();
            var mappedStudents = Mapper.Map<StudentDto[]>(students);
            return Ok(mappedStudents);
        }

        /// <summary>
        /// Add a finished quiz to an student.
        /// If now the lesson is finished, then the lessons is also added to the student.
        /// If now the course is finished, then the cours is also added to the student.
        /// </summary>
        /// <param name="userId">Id of the student</param>
        /// <param name="courseId">Course Id</param>
        /// <param name="lessonId">Lesson Id</param>
        /// <param name="quizId">Quiz Id</param>
        /// <returns>Http ok</returns>
        [HttpPut("{userId}/finishQuiz/{courseId}/{lessonId}/{quizId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddFinishedQuizToStudent([FromRoute] int userId, [FromRoute] int courseId, [FromRoute] int lessonId, [FromRoute] int quizId)
        {
            FinishedQuizService.AddFinishedQuizToStudent(userId, courseId, lessonId, quizId);
            return Ok();
        }
    }
}