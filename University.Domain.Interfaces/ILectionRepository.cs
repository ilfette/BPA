using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Core;

namespace University.Domain.Interfaces
{
  public  interface ILectionRepository 
    {
        Task<Lection> GetLectionAsync(int id);
        //Task<Lection> GetNameAsync(int id);

        Task<Lection> AddLectionAsync(Lection lection);

        Task<IEnumerable<Lection>> GetLectionsAsync();

        Task DeleteLectionAsync(int id);

        Task<Lection> UpdateLectionAsync(Lection lection);
    }
}
