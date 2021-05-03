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

        private StudentService StudentService { get; set; }
        private IMapper Mapper { get; set; }

        public StudentController(StudentService StudentService, IMapper mapper)
        {
            this.StudentService = StudentService;
            this.Mapper = mapper;
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
            var Student = StudentService.GetStudentWithId(id);
            if (Student == null) return StatusCode(StatusCodes.Status404NotFound);

            var mappedStudent = Mapper.Map<StudentDto>(Student);
            return Ok(mappedStudent);
        }

        /// <summary>
        /// Returns all Students.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<StudentDto[]> GetAllStudentzes()
        {
            var Students = StudentService.GetAllStudents();
            var mappedStudents = Mapper.Map<StudentDto[]>(Students);
            return Ok(mappedStudents);
        }







    }
}
