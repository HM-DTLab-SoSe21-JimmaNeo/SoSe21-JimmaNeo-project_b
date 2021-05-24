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
    [Route("api/Students")]
    public class StudentController : ControllerBase
    {

        private StudentService studentService { get; set; }
        private IMapper mapper { get; set; }

        public StudentController(StudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
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
        public ActionResult<Shared.DomainDTOs.StudentDto> GetStudentWithId([FromRoute] int id)
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

        /// Adds or updates a quiz definition.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentDto> AddOrUpdateQuiz([FromBody] StudentDto model)
        {
            if (ModelState.IsValid)
            {
                var mappedModel = mapper.Map<Student>(model);
                mappedModel = studentService.UpdateStudent(mappedModel);
                
                model = mapper.Map<StudentDto>(mappedModel);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }
    }
}
