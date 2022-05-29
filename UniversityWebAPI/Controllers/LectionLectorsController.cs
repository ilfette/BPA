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
    public class LectionLectorsController : ControllerBase
    {

        private readonly ILectionLectorsServices _lectionlectorsServices;
       

        public LectionLectorsController(ILectionLectorsServices lectionlectorsServices)
        {
            _lectionlectorsServices = lectionlectorsServices;
        }

        // получаем все лекции
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LectionLector>>> Get()
        {
            UniversityContext db = new UniversityContext();
            return await db.LectionLectors.ToListAsync();
        }

        // возвращает лекцию по переданному id.
        [HttpGet("{id}")]
        public async Task<ActionResult<LectionLector>> Get(int id)
        {
            var lection = await _lectionlectorsServices.GetLectionAsync(id);
            if (lection == null)
                return NotFound();
            return new ObjectResult(lection);
        }


        // получает из тела запроса отправленные данные и добавляет их в базу данных
        [HttpPost]
        public async Task<ActionResult<LectionLector>> Post(LectionLector lection)
        {
            if (lection == null)
            {
                return BadRequest();
            }

            await _lectionlectorsServices.AddLectionAsync(lection);
            return Ok(lection);
        }

        // получает данные из запроса и изменяет ими объект в базе данных
        [HttpPut]
        public async Task<ActionResult<LectionLector>> Put(LectionLector lection)
        {
            if (lection == null)
            {
                return BadRequest();
            }
            UniversityContext db = new UniversityContext();

            if (!db.Lections.Any(x => x.Id == lection.Id))
            {
                return NotFound();
            }

            await _lectionlectorsServices.UpdateLectionAsync(lection);
            //db.Update(user);
            //await db.SaveChangesAsync();
            return Ok(lection);
        }

        // получает из запроса параметр id и по данному идентификатору удаляет объект из БД
        [HttpDelete("{id}")]
        public async Task<ActionResult<LectionLector>> Delete(int id)
        {
            await _lectionlectorsServices.DeleteLectionAsync(id);
            return Ok(id);
        }

    }
}
