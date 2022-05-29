using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Core;
using University.Domain.Interfaces;
using University.Services.Interfaces;

namespace University.Infrastructure.Data
{
  public  class LectionServices : ILectionServices
    {
        private readonly ILectionRepository _lectionRepository;

        public LectionServices(ILectionRepository lectionRepository)
        {
            _lectionRepository = lectionRepository;
        }

        public async Task<Lection> AddLectionAsync(Lection lection)
        {
            return await _lectionRepository.AddLectionAsync(lection);
        }

        public async Task<IEnumerable<Lection>> GetLectionsAsync()
{
    return await _lectionRepository.GetLectionsAsync();
    }

    public async Task<Lection> GetLectionAsync(int id)
    {
        return await _lectionRepository.GetLectionAsync(id);
    }

    public async Task<Lection> UpdateLectionAsync(Lection lection)
    {
        return await _lectionRepository.UpdateLectionAsync(lection);
    }

    public async Task DeleteLectionAsync(int id)
    {
        await _lectionRepository.DeleteLectionAsync(id);
    }
}
}
