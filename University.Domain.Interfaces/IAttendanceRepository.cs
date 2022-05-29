using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Core;

namespace University.Domain.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance> GetAttendanceAsync(int id);

        Task<Attendance> AddAttendanceAsync(Attendance student);

        Task<IEnumerable<Attendance>> GetAttendanceAsync();

        Task DeleteAttendanceAsync(int id);

        Task<Attendance> UpdateAttendanceAsync(Attendance student);
    }
}
