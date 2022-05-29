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
    public class LectionRepository : ILectionRepository
    {
        public LectionRepository() { }

        // возвращение лекцию по id
        public async Task<Lection> GetLectionAsync(int id)
        {
            Lection result = null;

            using (var UniversityContext = new UniversityContext())
            {
                result = await UniversityContext.Lections.FirstOrDefaultAsync(f => f.Id == id);
            }
            return result;
        }

        // Добавление лекции
        public async Task<Lection> AddLectionAsync(Lection lection)
        {
            //Student result = null;

            using (var UniversityContext = new UniversityContext())
            {
                UniversityContext.Lections.Add(lection);
                //result = UniversityContext.Students.Add(student);
                await UniversityContext.SaveChangesAsync();
            }
            //return result;
            return lection;
        }

        // возвращение списка лекций
        public async Task<IEnumerable<Lection>> GetLectionsAsync()
        {
            var result = new List<Lection>();

            using (var UniversityContext = new UniversityContext())
            {
                result = await UniversityContext.Lections.ToListAsync();
            }
            return result;
        }

        // удаление лекции по id
        public async Task DeleteLectionAsync(int id)
        {
            using (var UniversityContext = new UniversityContext())
            {
                var lection = await UniversityContext.Lections.FirstOrDefaultAsync(f => f.Id == id);
                UniversityContext.Entry(lection).State = EntityState.Deleted;
                await UniversityContext.SaveChangesAsync();
            }
        }

        // обновление данных о лекции
        public async Task<Lection> UpdateLectionAsync(Lection lection)
        {
            using (var UniversityContext = new UniversityContext())
            {
                UniversityContext.Entry(lection).State = EntityState.Modified;
                await UniversityContext.SaveChangesAsync();
            }
            return lection;
        }
    }
}
