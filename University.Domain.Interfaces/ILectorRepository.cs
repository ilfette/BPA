using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Core;

namespace University.Domain.Interfaces
{
   public interface ILectorRepository 
    {


        Task<Lector> GetLectorAsync(int id);

        Task<Lector> AddLectorAsync(Lector lector);

        Task<IEnumerable<Lector>> GetLectorsAsync();

        Task DeleteLectorAsync(int id);

        Task<Lector> UpdateLectorAsync(Lector lector);



    }
}
