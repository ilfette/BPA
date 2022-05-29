using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Core;
namespace University.Services.Interfaces
{
   public interface ILectorServices
    {

        Task<Lector> AddLectorAsync(Lector lector);

        Task<IEnumerable<Lector>> GetLectorsAsync();

        Task<Lector> GetLectorAsync(int id);

        Task<Lector> UpdateLectorAsync(Lector lector);

        Task DeleteLectorAsync(int id);


    }
}
