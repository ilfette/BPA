using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Services.Interfaces.University.Services;
using University.Domain.Interfaces;
using University.Domain.Core;
using Microsoft.EntityFrameworkCore;


namespace University.Infrastructure.Data
{
    public class LectorRepository : ILectorRepository
    {
        public LectorRepository() { }

        // возвращение лектора по его id
        public async Task<Lector> GetLectorAsync(int id)
        {
            Lector result = null;
            using (var UniversityContext = new UniversityContext())
            {
                result = await UniversityContext.Lectors.FirstOrDefaultAsync(f => f.Id == id);
            }
            return result;
        }


        // Добавление лекторов
        public async Task<Lector> AddLectorAsync(Lector lector)
        {
            using (var UniversityContext = new UniversityContext())
            {
                UniversityContext.Lectors.Add(lector);
                await UniversityContext.SaveChangesAsync();
            }
            return lector;
        }

        // возвращение списка лекторов
        public async Task<IEnumerable<Lector>> GetLectorsAsync()
        {
            var result = new List<Lector>();

            using (var UniversityContext = new UniversityContext())
            {
                result = await UniversityContext.Lectors.ToListAsync();
            }
            return result;
        }

        // удаление лектора по id
        public async Task DeleteLectorAsync(int id)
        {
            using (var UniversityContext = new UniversityContext())
            {
                var lector = await UniversityContext.Lectors.FirstOrDefaultAsync(f => f.Id == id);
                UniversityContext.Entry(lector).State = EntityState.Deleted;
                await UniversityContext.SaveChangesAsync();
            }
        }

        // обновление данных о лекторе
        public async Task<Lector> UpdateLectorAsync(Lector lector)
        {
            using (var UniversityContext = new UniversityContext())
            {
                UniversityContext.Entry(lector).State = EntityState.Modified;
                await UniversityContext.SaveChangesAsync();
            }
            return lector;
        }
    }
}
