using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Core;
using University.Domain.Interfaces;
using University.Infrastructure.Data;
using University.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using University.Services.Interfaces.University.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Student>>> Get()
        //{
        //    return await db.Students.ToListAsync();
        //}

        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        // получаем всех студентов
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            UniversityContext db = new UniversityContext();
            return await db.Students.ToListAsync();
            //var student = await _studentServices.GetStudentsAsync();
        }

        // возвращает студента по переданному id.
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _studentServices.GetStudentAsync(id);
            if (student == null)
                return NotFound();
            return new ObjectResult(student);
        }

        // получает из тела запроса отправленные данные и добавляет их в базу данных
        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            await _studentServices.AddStudentAsync(student);
            return Ok(student);
        }

        // получает данные из запроса и изменяет ими объект в базе данных
        [HttpPut]
        public async Task<ActionResult<Student>> Put(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            UniversityContext db = new UniversityContext();

            if (!db.Students.Any(x => x.Id == student.Id))
            {
                return NotFound();
            }

            await _studentServices.UpdateStudentAsync(student);
            //db.Update(user);
            //await db.SaveChangesAsync();
            return Ok(student);
        }


        // получает из запроса параметр id и по данному идентификатору удаляет объект из БД
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            await _studentServices.DeleteStudentAsync(id);
            return Ok(id);
        }





    }




    //// GET: api/<StudentController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    //// GET api/<StudentController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/<StudentController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<StudentController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<StudentController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}

}
