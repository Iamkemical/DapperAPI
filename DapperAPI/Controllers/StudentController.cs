using Dapper;
using DapperAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent student;

        public StudentController(IStudent student)
        {
            this.student = student;
        }

        [HttpGet(nameof(GetAllStudent))]
        public async Task<ActionResult<Model>> GetAllStudent()
        {
            var students = await student.GetAllStudent();
            if (students is null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet(nameof(GetStudentById))]
        public async Task<ActionResult<Model>> GetStudentById(int id)
        {
            var students = await student.GetStudentById(id);
            if (students is null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpPost(nameof(CreateStudent))]
        public async Task<ActionResult<Model>> CreateStudent(Model model)
        {
            if (model is null)
            {
                return BadRequest();
            }
            var students = student.CreateStudent(model);
            if (students is null)
            {
                return BadRequest();
            }
            return Ok(students);
        }

        [HttpPut(nameof(UpdateStudent))]
        public async Task<ActionResult> UpdateStudent(Model model, int id)
        {
            var updatedStudent = student.UpdateStudent(model, id);
            if (updatedStudent is null)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete(nameof(DeleteStudent))]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var deletedStudent = student.DeleteStudent(id);
            if (deletedStudent is null)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
