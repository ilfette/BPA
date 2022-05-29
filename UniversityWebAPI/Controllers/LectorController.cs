using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Core;
using University.Domain.Interfaces;
using University.Infrastructure.Data;
using University.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using University.Services.Interfaces.University.Services;

namespace UniversityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorController : ControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Lector>>> Get()
        //{
        //    return await db.Lectors.ToListAsync();
        //}

        private readonly ILectorServices _lectorServices;

        public LectorController(ILectorServices lectorServices)
        {
            _lectorServices = lectorServices;
        }

        //получаем всех лекторов
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lector>>> Get()
        {
            UniversityContext db = new UniversityContext();
            return await db.Lectors.ToListAsync();
        }

        // возвращает лектора по переданному id.
        [HttpGet("{id}")]
        public async Task<ActionResult<Lector>> Get(int id)
        {
            var lector = await _lectorServices.GetLectorAsync(id);
            if (lector == null)
                return NotFound();
            return new ObjectResult(lector);
        }

        // получает из тела запроса отправленные данные и добавляет их в базу данных
        [HttpPost]
        public async Task<ActionResult<Lector>> Post(Lector lector)
        {
            if (lector == null)
            {
                return BadRequest();
            }
            await _lectorServices.AddLectorAsync(lector);
            return Ok(lector);
        }

        // получает данные из запроса и изменяет ими объект в базе данных
        [HttpPut]
        public async Task<ActionResult<Lector>> Put(Lector lector)
        {
            if (lector == null)
            {
                return BadRequest();
            }
            UniversityContext db = new UniversityContext();

            if (!db.Lectors.Any(x => x.Id == lector.Id))
            {
                return NotFound();
            }

            await _lectorServices.UpdateLectorAsync(lector);
            return Ok(lector);
        }


        // получает из запроса параметр id и по данному идентификатору удаляет объект из БД
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lector>> Delete(int id)
        {
            await _lectorServices.DeleteLectorAsync(id);
            return Ok(id);
        }
    }
}
