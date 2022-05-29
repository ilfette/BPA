using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Interfaces;
using University.Domain.Core;
using University.Services.Interfaces;
using University.Services.Interfaces.University.Services;
using Microsoft.EntityFrameworkCore;

namespace University.Infrastructure.Data
{
   public class AttendanceRepository : IAttendanceRepository
    {
        public AttendanceRepository() { }

        // возвращение студента по его id
        public async Task<Attendance> GetAttendanceAsync(int id)
        {
            Attendance result = null;

            using (var UniversityContext = new UniversityContext())
            {
                result = await UniversityContext.Attendances.FirstOrDefaultAsync(f => f.Id == id);
            }
            return result;
        }


        // Добавление студентов
        public async Task<Attendance> AddAttendanceAsync(Attendance student)
        {
            //Student result = null;

            using (var UniversityContext = new UniversityContext())
            {
                UniversityContext.Attendances.Add(student);
                //result = UniversityContext.Students.Add(student);
                await UniversityContext.SaveChangesAsync();
            }
            //return result;
            return student;
        }

        // возвращение списка студентов
        public async Task<IEnumerable<Attendance>> GetAttendanceAsync()
        {
            var result = new List<Attendance>();

            using (var UniversityContext = new UniversityContext())
            {
                result = await UniversityContext.Attendances.ToListAsync();
            }
            return result;
        }

        // удаление студента по id
        public async Task DeleteAttendanceAsync(int id)
        {
            using (var UniversityContext = new UniversityContext())
            {
                var student = await UniversityContext.Attendances.FirstOrDefaultAsync(f => f.Id == id);
                UniversityContext.Entry(student).State = EntityState.Deleted;
                await UniversityContext.SaveChangesAsync();
            }
        }

        // обновление данных о студенте
        public async Task<Attendance> UpdateAttendanceAsync(Attendance student)
        {
            using (var UniversityContext = new UniversityContext())
            {
                UniversityContext.Entry(student).State = EntityState.Modified;
                await UniversityContext.SaveChangesAsync();
            }
            return student;
        }
    }
}
